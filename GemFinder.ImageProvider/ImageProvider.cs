using GemFinder.ImageProvider.Helper;
using GemFinder.ImageProvider.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;

namespace GemFinder.ImageProvider
{
    public class ImageProvider : IImageProvider
    {
        private DownloadHelper downloadHelper;
        private string projectPath;
        private const string DIRECTORY_NAME = "Images";
        private const int FIELD_ID = 270;

        public ImageProvider()
        {
            //TODO universal path
            downloadHelper = new DownloadHelper();
            projectPath = Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\"));
            projectPath = System.Reflection.Assembly.GetAssembly(typeof( DownloadHelper)).Location;
            projectPath = @"C:\Users\User\Documents\GitHub\GemFinder\GemFinder.ImageProvider";
        }

        public void DownloadImages(string[] imageNames = null, int? imagesNumber = null, string pathToSave = null, string mainTopic = null)
        {
            var numberOfImages = imagesNumber ?? Configuration.NumberOfImages;
            pathToSave = pathToSave ?? Configuration.StoredImagesPath ?? Path.Combine(projectPath, DIRECTORY_NAME);
            imageNames = imageNames ?? Configuration.ImageNames;
            mainTopic = mainTopic ?? Configuration.MainTopic;

            foreach (var name in imageNames)
            {
                int offset = 0;
                while (offset < numberOfImages)
                {
                    var html = downloadHelper.GetHtmlCode(name, offset, mainTopic);
                    var urls = downloadHelper.GetUrls(html);
                    foreach (var url in urls)
                    {
                        var image = downloadHelper.GetImageFromUrl(url.DowloadUrl);
                        if (image == null)
                            continue;

                        downloadHelper.SetImageComment(image, url.SourceUrl, FIELD_ID);
                        downloadHelper.SaveImage(image, pathToSave, name);

                        offset++;
                        if (offset >= numberOfImages)
                            break;
                    }
                }
            }
        }

        public new IList<FileItem> GetStoredImagesInfo(string path = null)
        {
            var mainFolderPath = path ?? Configuration.StoredImagesPath ?? Path.Combine(projectPath, DIRECTORY_NAME);
            var folderNames = Directory.GetDirectories(mainFolderPath)
                .Select(Path.GetFileName).ToArray();
            List<FileItem> result = new List<FileItem>();

            foreach (var folder in folderNames)
            {
                var objectFoldrPath = Path.Combine(mainFolderPath, folder);
                var imageNames = Directory.GetFiles(objectFoldrPath).Select(Path.GetFileName).ToArray();

                foreach (var fileName in imageNames)
                {
                    var id = fileName.Replace(".jpeg", String.Empty);
                    var img = Image.FromFile(Path.Combine(objectFoldrPath, fileName));
                    var property = img.GetPropertyItem(270);
                    var source = System.Text.Encoding.UTF8.GetString(property.Value);
                    result.Add(new FileItem(new Guid(id), folder, source, objectFoldrPath, fileName));
                }
            }

            return result;
        }
    }
}
