namespace GemFinder.Identity.Service
{
    public interface IRng
    {
        string Generate(int length = 50, bool removeSpecialChars = false);
    }
}