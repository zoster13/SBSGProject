using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCFService
{
    public class WCFService : IWCFService
    {
        public void AddEntity(string message)
        {
            //informacije o klijentu koji poziva metodu 
            WindowsIdentity winIdentity = Thread.CurrentPrincipal.Identity as WindowsIdentity;
            
            //Novi entitet koji se upisuje u bazu
            Entity entity = new Entity();
            entity.Message = message;
            entity.Username = winIdentity.Name;
            entity.UniqueId = Guid.NewGuid();
            entity.TimeStamp = DateTime.Now;
            //Odredjivnaje Securityidentifiera
            var account = new NTAccount(winIdentity.Name);
            entity.Sid = account.Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;

            ShowEntity(entity);

            SaveToDatabase(entity);
        }

        private void SaveToDatabase(Entity entity)
        {
            using (StreamWriter writer = File.AppendText(@"..\..\..\Database.txt"))
            {
                writer.WriteLine("Entity:");
                writer.WriteLine("\tUnique ID: {0}", entity.UniqueId);
                writer.WriteLine("\tTimestamp: {0}", entity.TimeStamp.ToString());
                writer.WriteLine("\tClient name: {0}", entity.Username);
                writer.WriteLine("\tSID: {0}", entity.Sid);
                writer.WriteLine("\tMessage: {0}", entity.Message);
                writer.WriteLine("------------------------------------------------------------");
            }
        }

        private void ShowEntity(Entity entity)
        {
            Console.WriteLine("\nEntity:");
            Console.WriteLine("\tUnique ID: {0}", entity.UniqueId);
            Console.WriteLine("\tTimestamp: {0}", entity.TimeStamp.ToString());
            Console.WriteLine("\tClient name: {0}", entity.Username);
            Console.WriteLine("\tSID: {0}", entity.Sid);
            Console.WriteLine("\tMessage: {0}", entity.Message);
        }
    }
}
