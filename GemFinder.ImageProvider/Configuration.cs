using System;
using System.Configuration;

namespace GemFinder.ImageProvider
{
    internal static class Configuration
    {
        public static string StoredImagesPath => ConfigurationManager.AppSettings["StoredImagesPath"];

        public static int NumberOfImages => Int32.Parse(ConfigurationManager.AppSettings["NumberOfImages"]);

        public static string[] ImageNames => ConfigurationManager.AppSettings["ImageNames"].Split(',');

        public static string MainTopic => ConfigurationManager.AppSettings["MainTopic"];
    }
}