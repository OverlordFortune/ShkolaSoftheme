using System;
using System.Runtime.Serialization;
namespace _21._1
{
    [DataContract]
    [Serializable]
    public class Account
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
