
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Task_03_11;

namespace Plugins
{

    public class XMLPlugin : ISerializePlugin
    {
       

        public string Name => "XML";
        public string Description => "Extensible Markup Language is a markup language that defines a set of rules for\r\n encoding documents in a format that is both human-readable and machine-readable. ";

        public Person Deserialize(string pathForDeserialize)
        {
            Person person;
            var serializer = new XmlSerializer(typeof(Person));
            using (var reader = XmlReader.Create(pathForDeserialize))
            {
                person = (Person)serializer.Deserialize(reader);
            }
            return person;
        }

        public void Serialize(Person person)
        {
            string date = DateTime.Now.ToString("yyyyMMddTHH_mm_ssZ");
            string path = @$"c:/forms/person{date}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream fsSources = new FileStream(path, FileMode.CreateNew))
            {
                using (StreamWriter swr = new StreamWriter(fsSources))
                {
                    serializer.Serialize(swr, person);
                    swr.Close();
                }
            }
        }
    }

}
