namespace DISample
{
    public static class Helper
    {
        static int s_accessNumber = 0;

        // public static int WriteResult(this string str)
        public static int WriteResult()
        {
            s_accessNumber++;
            return s_accessNumber;
        }

        public static Logger WriteResult2()
        {
            s_accessNumber++;
            return new Logger(s_accessNumber % 2, "e");
        }
    }
}
