namespace Common
{
    public static class StringExtension
    {
        public static string SplitToKeyValue(this string value, int index)
        {
            return value.Split(':')[index].Trim();
        }
    }
}