namespace GameEditor.Wcf.Harness.Wpf.Extensions
{
    public static class StringExtender
    {
        public static int ConvertToInt(this string value, int defaultValue = 0)
        {
            int result;
            return int.TryParse(value, out result) ? result : defaultValue;
        }
    }
}