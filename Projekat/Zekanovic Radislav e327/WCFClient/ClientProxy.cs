using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    public class ClientProxy : ChannelFactory<IWCFService>, IWCFService, IDisposable
    {
        IWCFService factory;

        public ClientProxy(NetTcpBinding binding, string address) : base(binding,address)
        {
            factory = this.CreateChannel();
        }

        public void AddEntity(string message)
        {
            try
            {
                factory.AddEntity(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        
        }
    }
}
