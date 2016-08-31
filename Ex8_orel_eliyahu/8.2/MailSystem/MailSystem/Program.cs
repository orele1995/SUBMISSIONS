using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mailManager = new MailManager();
            mailManager.MailArrived += (obj, eventArgs) => Console.WriteLine(string.Format("The messege is: {0} {1}",eventArgs.Title, eventArgs.Body));
            mailManager.SimulateMailArrived();
            System.Threading.Timer timer = new System.Threading.Timer(o => mailManager.SimulateMailArrived(),null,0,1000);
            Console.ReadLine();
        }
    }
}
