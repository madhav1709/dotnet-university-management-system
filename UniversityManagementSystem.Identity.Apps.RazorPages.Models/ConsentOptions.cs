namespace UniversityManagementSystem.Identity.Apps.RazorPages.Models
{
    public static class ConsentOptions
    {
        static ConsentOptions()
        {
            EnableOfflineAccess = true;
            OfflineAccessDisplayName = "Offline Access";
            OfflineAccessDescription = "Access to your applications and resources, even when you are offline";
            MustChooseOneErrorMessage = "You must pick at least one permission";
            InvalidSelectionErrorMessage = "You have made an invalid selection";
        }

        public static bool EnableOfflineAccess { get; }

        public static string OfflineAccessDisplayName { get; }

        public static string OfflineAccessDescription { get; }

        public static string MustChooseOneErrorMessage { get; }

        public static string InvalidSelectionErrorMessage { get; }
    }
}