using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.ImageProvider
{
    public interface IImageProvider
    {
        public void DownloadImages(string[] names, int? number = null);
        public object GetStoredImagesSource();
        public string[] GetStoredModels();
    }
}
