using GemFinder.ImageProvider.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.ImageProvider
{
    public interface IImageProvider
    {
        public void DownloadImages(string[] imageNames = null, int? imagesNumber = null, string pathToSave = null, string mainTopic = null);
        public IList<FileItem> GetStoredImagesInfo(string path = null);
    }
}
