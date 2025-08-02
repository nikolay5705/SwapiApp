namespace SWAPI.ValidationData
{
    public static class ValidationData
    {
        public static bool IsExit(string? name)
        {
            if (name == "exit")
                return true;
            else
                return false;
        }

        public static bool IsUnknownCategory(string? name)
        {
            if (name != "people" && name != "planets" && name != "starships")
                return true;
            else
                return false;
        }
    }
}