using System.Windows.Forms;
using Microsoft.Xrm.Sdk;

namespace Carfup.XTBPlugins.AppCode
{
    public class PluginSettings
    {
        public bool? AllowLogUsage { get; set; }
        public string CurrentVersion { get; set; } = BPFManager.BPFManager.CurrentVersion;
        public int NumberOfRecordPerRound { get; set; } = 1000;
    }

    // EventType to qualify which type of telemetry we send
    static class EventType
    {
        public const string Event = "event";
        public const string Trace = "trace";
        public const string Dependency = "dependency";
        public const string Exception = "exception";
    }

    public static class CustomParameter
    {
        public static string INSIGHTS_INTRUMENTATIONKEY = "INSIGHTS_INTRUMENTATIONKEY_TOREPLACE";
    }

    // EventType to qualify which action was performed by the plugin
    static class LogAction
    {
        public const string PluginClosed = "PluginClosed";
        public const string StatsAccepted = "StatsAccepted";
        public const string StatsDenied = "StatsDenied";
        public const string SettingsSaved = "SettingsSaved";
        public const string SettingLoaded = "SettingLoaded";
        public const string PluginOpened = "PluginOpened";
        public const string FXBBuilerUsed = "FXBBuilerUsed";
        public const string RecordsToMigrateRetrieved = "RecordsToMigrateRetrieved";
        public const string UsersRetrieved = "UsersRetrieved";
        public const string RelatedBPFRetrieved = "RelatedBPFRetrieved";
        public const string RelatedBPFStagesRetrieved = "RelatedBPFStagesRetrieved";
        public const string RecordsMigrated = "RecordsMigrated";
        public const string EntitiesWithBPFRetrieved = "EntitiesWithBPFRetrieved";
        public const string BPFEntityViewsRetrieved = "BPFEntityViewsRetrieved";
        public const string MigrationCancelled = "MigrationCancelled";
        public const string NoBPFForEntity = "NoBPFForEntity";
        public const string NoStagesForBPF = "NoStagesForBPF";
    }


    public class MigrationError
    {
        public OrganizationRequest request { get; set; }
        public OrganizationServiceFault fault { get; set; }
    }
}
