using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/WCFService";

            using(ClientProxy proxy = new ClientProxy(binding,address))
            {
                proxy.AddEntity("prva poruka.");
            }

            Console.WriteLine("Press <enter> to stop client...");
            Console.ReadLine();
        }
    }
}
