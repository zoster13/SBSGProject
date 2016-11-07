using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [DataContract]
    public class Entity
    {
        private string message;
        private SecurityIdentifier sid;
        private Guid uniqueId;
        private string username;
        private DateTime timeStamp;

        public Entity() 
        {
        }

        public Entity(string message, SecurityIdentifier sid, string username, DateTime timeStamp)    
        {
            this.message = message;
            this.sid = sid;
            this.username = username;
            this.timeStamp = timeStamp;
        }

        [DataMember]
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        [DataMember]
        public SecurityIdentifier Sid
        {
            get { return this.sid; }
            set { this.sid = value; }
        }

        [DataMember]
        public Guid UniqueId
        {
            get { return this.uniqueId; }
            set { this.uniqueId = value; }
        }

        [DataMember]
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        [DataMember]
        public DateTime TimeStamp
        {
            get { return this.timeStamp; }
            set { this.timeStamp = value; }
        }
    }
}
