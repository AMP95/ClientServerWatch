using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatchServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WhatchSender sender = new WhatchSender();
            sender.Start();
        }
    }
}
