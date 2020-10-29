namespace GemFinder.ImageProvider.Model
{
    internal class UrlItem
    {
        public string DowloadUrl { get; }
        public string SourceUrl { get; }

        public UrlItem(string dowloadUrl, string sourceUrl)
        {
            DowloadUrl = dowloadUrl;
            SourceUrl = sourceUrl;
        }
    }
}
