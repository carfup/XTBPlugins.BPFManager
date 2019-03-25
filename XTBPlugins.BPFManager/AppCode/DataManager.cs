using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace Carfup.XTBPlugins.AppCode
{
    public class DataManager
    {
        public IOrganizationService service { get; set; } = null;
        public int recordToRetrieveEachRound = 5000;

        public DataManager(IOrganizationService service)
        {
            this.service = service;
        }

        public List<Entity> GetRecordsToMigrate(string fetchXmlQuery, BackgroundWorker worker = null)
        {
            List<Entity> recordToMigrate = new List<Entity>();
            QueryExpression query = ConvertFetchXMLtoQueryExpression(fetchXmlQuery);
            query.NoLock = true;

            if(query.TopCount == null)
            {
                query.PageInfo = new PagingInfo
                {
                    Count = recordToRetrieveEachRound,
                    PageNumber = 1
                };
            }


            EntityCollection ec;
            int total = 0;
            do
            {
                ec = service.RetrieveMultiple(query);
                total += ec.Entities.Count;
                if (query.TopCount == null)
                {
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = ec.PagingCookie;
                }

                worker?.ReportProgress(0, $"{total} records retrieved...");


                recordToMigrate.AddRange(ec.Entities);
                //foreach (var record in ec.Entities)
                //{
                //    recordToMigrate.Add(record);

                //}
            } while (ec.MoreRecords /*&& Cancel == false*/);

            //var result = this.service.RetrieveMultiple(query);

            return recordToMigrate;
        }

        public List<Entity> GetUsers(BackgroundWorker worker = null)
        {
            List<Entity> users = new List<Entity>();
            var query = new QueryExpression()
            {
                EntityName = "systemuser",
                ColumnSet = new ColumnSet("fullname"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("isdisabled", ConditionOperator.Equal, "0"),
                        new ConditionExpression("lastname", ConditionOperator.NotIn,
                            new string[] {"SYSTEM", "INTEGRATION"}),
                        new ConditionExpression("domainname", ConditionOperator.NotNull),
                        new ConditionExpression("domainname", ConditionOperator.NotEqual, ""),
                        new ConditionExpression("accessmode", ConditionOperator.NotIn, new string[] {"3", "5"}),
                    }
                },
                PageInfo =
                {
                    Count = recordToRetrieveEachRound,
                    PageNumber = 1
                },
                NoLock = true
            };


            EntityCollection ec;
            int total = 0;
            do
            {
                ec = service.RetrieveMultiple(query);
                total += ec.Entities.Count;
                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = ec.PagingCookie;

                worker?.ReportProgress(0, $"{total} records retrieved...");

                users.AddRange(ec.Entities);
                
            } while (ec.MoreRecords /*&& Cancel == false*/);

            return users;
        }

        public List<Entity> GetProperBPFList(string bpfSelectedEntityTarget, List<Entity> recordToMigrateList, string attrForCondition)
        {
            List<Entity> resultQueryProperBPF = new List<Entity>();

            var query = new QueryExpression()
            {
                EntityName = bpfSelectedEntityTarget,
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression(attrForCondition, ConditionOperator.In,
                            recordToMigrateList.Select(x => x.Id as object).ToArray<object>())
                    }
                },
                PageInfo =
                {
                    Count = recordToRetrieveEachRound,
                    PageNumber = 1
                },
                NoLock = true
            };
            

            EntityCollection ec;
            int total = 0;
            do
            {
                ec = service.RetrieveMultiple(query);
                total += ec.Entities.Count;
                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = ec.PagingCookie;

                resultQueryProperBPF.AddRange(ec.Entities);

            } while (ec.MoreRecords /*&& Cancel == false*/);

            return resultQueryProperBPF;
        }

        public List<Entity> GetRelatedBPF(string recordEntityToMigrate)
        {
            return this.service.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "workflow",
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("category", ConditionOperator.Equal, 4),
                        new ConditionExpression("primaryentity", ConditionOperator.Equal, recordEntityToMigrate)
                    }
                }
            }).Entities.ToList();
        }

        public List<Entity> GetBPFStages(Guid bpfSelected)
        {
            return this.service.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "processstage",
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("processid", ConditionOperator.Equal, bpfSelected)
                    }
                }
            }).Entities.ToList();
        }

        public string[] GetEntitiesWithBPF()
        {
            var query = new QueryExpression()
            {
                EntityName = "workflow",
                ColumnSet = new ColumnSet("primaryentity"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("category", ConditionOperator.Equal, 4),
                    }
                }
            };

            var result = this.service.RetrieveMultiple(query).Entities;

            return result.GroupBy(x => x.Attributes["primaryentity"]).Select(w => (string)w.Key).ToArray();
        }

        public List<Entity> GetViewsOfEntity(string entity)
        {
            var queryUserViews = this.service.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "userquery",
                ColumnSet = new ColumnSet("name", "fetchxml"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("returnedtypecode", ConditionOperator.Equal, entity)
                    }
                }
            });

            var querySystemViews = this.service.RetrieveMultiple(new QueryExpression()
            {
                EntityName = "savedquery",
                ColumnSet = new ColumnSet("name", "fetchxml"),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("returnedtypecode", ConditionOperator.Equal, entity)
                    }
                }
            });

            var allViews = querySystemViews.Entities.Union(queryUserViews.Entities);

            return allViews.ToList();
        }

        private QueryExpression ConvertFetchXMLtoQueryExpression(string fetchXmlQuery)
        {
            FetchXmlToQueryExpressionRequest conversionRequest = new FetchXmlToQueryExpressionRequest
            {
                FetchXml = fetchXmlQuery
            };

            FetchXmlToQueryExpressionResponse conversionResponse =
                (FetchXmlToQueryExpressionResponse)service.Execute(conversionRequest);

            QueryExpression queryExpression = conversionResponse.Query;

            return queryExpression;
        }

        public string GetPrimaryNameAttributeOfEntity(string entity)
        {
            var request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Entity,
                LogicalName = entity
            };

            var metadata = (RetrieveEntityResponse)service.Execute(request);
            return metadata.EntityMetadata.PrimaryNameAttribute;
        }
    }
}
