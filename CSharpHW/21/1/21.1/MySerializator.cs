using System;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace _21._1
{
    class MyAcountSerializator
    {
        public static bool BinarySerializer(MobileAccount account)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(account.Number + "Binary"  + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, account);
                return true;
            }

            return false;
        }
    
        public static bool XmlSerializer(MobileAccount account)
        {
            XmlSerializer xmlSerializer  = new XmlSerializer(typeof(MobileAccount));

            using (FileStream fs = new FileStream( account.Number + "XML" + ".xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, account);
                return true;
            }

            return false;
        }
    

        public static bool JsonSerializer(MobileAccount account)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(MobileAccount));

            using (FileStream fs = new FileStream(account.Number + "JSON" + ".json", FileMode.OpenOrCreate))
            {                
                jsonSerializer.WriteObject(fs, account);
                return true;
            }

            return false;
        }
    }
}
