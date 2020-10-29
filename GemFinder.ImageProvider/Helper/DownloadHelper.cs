using GemFinder.ImageProvider.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace GemFinder.ImageProvider.Helper
{
    internal class DownloadHelper
    {
        public string GetHtmlCode(string topic, int offset = 0, string mainTopic = null)
        {
            var searchValue = mainTopic != null ? topic + " " + mainTopic : topic;
            searchValue = searchValue.Replace(" ", "+");
            string url = $"https://www.google.com/search?q={searchValue}&tbm=isch&start={offset}&tbs=ift:jpg";
            string data = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
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

        public List<UrlItem> GetUrls(string html)
        {
            const string IMAGE_INDEX_BEGIN = "data-src=\"";
            const string SOURCE_INDEX_BEGIN = "href=\"";
            const string INDEX_END = "\"";
            const string IMG_INDEX_SECTION = "<img";
            const string TABLE_INDEX_SECTION = "class=\"islrc\"";

            var urls = new List<UrlItem>();
            int index = html.IndexOf(TABLE_INDEX_SECTION, StringComparison.Ordinal);
            index = html.IndexOf(IMG_INDEX_SECTION, index, StringComparison.Ordinal);

            while (index >= 0)
            {
                index = html.IndexOf(IMAGE_INDEX_BEGIN, index, StringComparison.Ordinal);
                index = index + IMAGE_INDEX_BEGIN.Length;
                int endIndex = html.IndexOf(INDEX_END, index, StringComparison.Ordinal);
                string url = html.Substring(index, endIndex - index);

                index = html.IndexOf(SOURCE_INDEX_BEGIN, index, StringComparison.Ordinal);
                index = index + SOURCE_INDEX_BEGIN.Length;
                endIndex = html.IndexOf(INDEX_END, index, StringComparison.Ordinal);
                string urlHref = html.Substring(index, endIndex - index);
                urls.Add(new UrlItem(url, urlHref));
                index = html.IndexOf(IMG_INDEX_SECTION, index, StringComparison.Ordinal);
            }
            return urls;
        }

        public string UniqueName()
        {
            return Guid.NewGuid().ToString();
        }

        public Image GetImageFromUrl(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                return Image.FromStream(dataStream);

            }
        }

        public void SaveImage(Image img, string path, string name)
        {
            var folderName = name.Replace(" ", "_").Trim();
            string imagePath = Path.Combine(path, folderName);

            if (!Directory.Exists(imagePath))
                Directory.CreateDirectory(imagePath);       

            try
            {
                img.Save(Path.Combine(imagePath, UniqueName() + ".jpeg"), ImageFormat.Jpeg);
            }
            catch
            {

            }
        }

        public void SetImageComment(Image img, string url, int fieldId)
        {
            PropertyItem item = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
            var itemData = Encoding.UTF8.GetBytes(url + "X");
            itemData[itemData.Length - 1] = 0;
            item.Type = 2; 
            item.Id = fieldId; 
            item.Len = itemData.Length; 
            item.Value = itemData; 

            img.SetPropertyItem(item); 
        }
    }
}

