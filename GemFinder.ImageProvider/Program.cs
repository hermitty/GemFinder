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

        //pobieranie zdjec
        //wyswietlanie zasobow
        //zarzadzanie zasobami


        //remove folders
        //browse folders
        //number 
        //2 words name
        //alias and search label
        private static readonly List<string> _topics = new List<string> { "labradorite" };

        static void Main(string[] args)
        {
            var imageProvider = new ImageProvider();
            string[] images = { "labradorite", "moon stone", "obsidian" };
            imageProvider.GetStoredModels();
            //imageProvider.DownloadImages(images);
            //Console.WriteLine("Hello World!");
            //var html = GetHtmlCode();
            //var urls = GetUrls(html);
            //var rnd = new Random();

            //int randomUrl = rnd.Next(0, urls.Count - 1);

            //string luckyUrl = urls[randomUrl];

            //byte[] image = GetImage(luckyUrl);



        }
        public static string GetHtmlCode()
        {
            var rnd = new Random();

            int topic = 0;

            string url = "https://www.google.com/search?q=" + _topics[topic] + "&tbm=isch&start=100";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return "";
                using (var sr = new StreamReader(dataStream))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        private static List<string> GetUrls(string html)
        {
            var urls = new List<string>();
            int ndx = html.IndexOf("class=\"GpQGbf\"", StringComparison.Ordinal);
            ndx = html.IndexOf("<img", ndx, StringComparison.Ordinal);

            while (ndx >= 0)
            {
                ndx = html.IndexOf("src=\"", ndx, StringComparison.Ordinal);
                ndx = ndx + 5;
                int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                string url = html.Substring(ndx, ndx2 - ndx);
                urls.Add(url);
                ndx = html.IndexOf("<img", ndx, StringComparison.Ordinal);
            }
            return urls;
            //&as_rights=cc_publicdomain
            //&start = 20
        }

        private static byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

  
            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                Image img = System.Drawing.Image.FromStream(dataStream);

                img.Save(Path.Combine(Configuration.StoredImagesPath, "myImage.Jpeg"), ImageFormat.Jpeg);

            }

            // Construct a bitmap from the button image resource.
           

            return null;
        }
    }
}
