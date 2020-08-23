using System;
using System.Configuration;

namespace GemFinder.ImageProvider
{
    internal static class Configuration
    {
        public static string StoredImagesPath
        {
            get
            {
                return ConfigurationManager.AppSettings["StoredImagesPath"];
            }
        }

        public static int NumberOfImages
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings["NumberOfImages"]) ;
            }
        }
    }
}