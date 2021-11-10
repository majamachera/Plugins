
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Task_03_11;

namespace Plugins
{
    public class JSONPlugin : ISerializePlugin
    {
       
        public string Name => "JSON";

        public string Description => "JSON is an open standard file format and data interchange format that uses human-readable text\r\n to store and transmit data objects consisting of attribute–value pairs and arrays. \r\n It is a common data format with diverse uses in electronic data interchange,\r\n including that of web applications with servers.";

        public Person Deserialize(string pathForDeserialize)
        {
            String JSONtxt = File.ReadAllText(pathForDeserialize);
            var person = JsonConvert.DeserializeObject<Person>(JSONtxt);
            return person;
        }

        public void Serialize(Person person)
        {
            string date = DateTime.Now.ToString("yyyyMMddTHH_mm_ssZ");
            using (FileStream fs = File.Open(@$"c:\forms\person{date}.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, person);
            }
        }
    }
}
