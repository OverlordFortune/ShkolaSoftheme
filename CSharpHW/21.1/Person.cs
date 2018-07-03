using System.Runtime.Serialization;

namespace _21._1
{
    [DataContract]
    internal class Person
    {
        [DataMember]
        internal string Name;

        [DataMember]
        internal int Age;
    }
}
