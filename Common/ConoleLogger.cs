using System;

namespace Common
{
    internal class ConoleLogger : ILogger
    {
        public void Write(string log)
        {
            Console.WriteLine(log);
        }
    }
}
