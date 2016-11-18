using System;
using System.Runtime.Serialization;

namespace CSharkLibrary
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Username;

        [DataMember]
        public DateTime LoginTime;

        public override string ToString()
        {
            return Username;
        }
    }
}
