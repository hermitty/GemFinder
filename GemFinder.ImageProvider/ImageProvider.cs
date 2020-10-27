using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace GemFinder.ImageProvider
{
    public class ImageProvider : IImageProvider
    {

        public void DownloadImages(string[] names, int? numberOfImages = null)
        {
            if (numberOfImages == null)
                numberOfImages = Configuration.NumberOfImages;

            foreach (var name in names)
            {
                DownloadImagesForName(name, numberOfImages);
            }
        }

        private void DownloadImagesForName(string name, int? numberOfImages)
        {
            int offset = 0;
            while (offset < numberOfImages)
            {
                var html = GetHtmlCode(name, offset);
                var urls = GetUrls(html);
                foreach (var url in urls)
                {
                    SaveImageFromUrl(url, name);

                    offset++;
                    if (offset >= numberOfImages)
                        break;
                }
            }
        }

        private string GetHtmlCode(string topic, int offset = 0)
        {
            topic = topic.Replace(" ", "+");
            topic = topic + "+stone";
            //remove spaces
            //&as_rights=cc_publicdomain
            //&start = 20
            string url = $"https://www.google.com/search?q={topic}&tbm=isch&start={offset}&tbs=ift:jpg";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);//TODO try catch
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
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

        private List<string> GetUrls(string html)
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
        }

        private void SaveImageFromUrl(string url, string name)
        {
            //TODO try catch
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)request.GetResponse();
                var folderName = name.Replace(" ", "_");

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return;
                    Image img = System.Drawing.Image.FromStream(dataStream);
                    SetImageComment(img, url);

                    var imagePath = Path.Combine(Configuration.StoredImagesPath, folderName);
                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }

                    try
                    {
                        //img.Save(Path.Combine(Configuration.StoredImagesPath, folderName, url + ".Jpeg"), ImageFormat.Jpeg);
                        // 

                        img.Save(Path.Combine(imagePath, UniqueName() + ".jpeg"), ImageFormat.Jpeg);
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
           
        }

        private string UniqueName()
        {
            return Guid.NewGuid().ToString();
        }

        private void SetImageComment(Image img, string url)
        {
            PropertyItem item = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));

            // This will assign "Joe Doe" to the "Authors" metadata field
            //string sTmp = "Joe DoeX"; // The X will be replaced with a null.  String must be null terminated.
            var itemData = System.Text.Encoding.UTF8.GetBytes(url + "X");
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            item.Type = 2; //String (ASCII)
            item.Id = 270; // Author(s), 315 is mapped to the "Authors" field
            item.Len = itemData.Length; // Number of items in the byte array
            item.Value = itemData; // The byte array
            img.SetPropertyItem(item); // Assign / add to the bitmap

        }

        public object GetStoredImagesSource()
        {
            throw new NotImplementedException();
        }

        public string[] GetStoredModels()
        {
            var a = Directory.GetDirectories(Configuration.StoredImagesPath).Select(Path.GetFileName)
                            .ToArray();
            return a;
        }
    }
}
