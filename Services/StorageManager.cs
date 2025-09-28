using AplikacjaDoMagazynu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AplikacjaDoMagazynu.Services
{
    public class StorageManager
    {
        private string filePath = "data.xml";
        private string LogfilePath = "Log.xml";

        public List<Item> LoadItems()
        {
            if (!File.Exists(filePath)) return new List<Item>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<Item>)serializer.Deserialize(fs);
            }
        }

        public void SaveItems(List<Item> Items)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, Items);
            }
        }
        public List<LogEntry> LoadLogs()
        {
            if (!File.Exists(LogfilePath)) return new List<LogEntry>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<LogEntry>));
            using (FileStream fs = new FileStream(LogfilePath, FileMode.Open))
            {
                return (List<LogEntry>)serializer.Deserialize(fs);
            }
        }

        public void SaveLogs(List<LogEntry> Items)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<LogEntry>));
            using (FileStream fs = new FileStream(LogfilePath, FileMode.Create))
            {
                serializer.Serialize(fs, Items);
            }
        }
    }
}
