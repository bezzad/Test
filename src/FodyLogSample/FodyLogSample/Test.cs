using Anotar.NLog;


namespace FodyLogSample
{
    
    public class Test
    {
        string Name;

        public Test(string name)
        {
            Name = name;
        }

        //[LogToErrorOnException]
        public void DisplayTest()
        {
            LogTo.Debug(Name);
        }
    }
}
