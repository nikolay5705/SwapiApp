namespace SWAPI.Utils;

public static class Utils
{
    public static string ExtractIdFromUrl(string url)
    {
        return url.TrimEnd('/').Split('/').Last();
    }
}
