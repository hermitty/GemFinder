using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace GemFinder.ImageProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var imageProvider = new ImageProvider();
            imageProvider.DownloadImages();
        }
    }
}
