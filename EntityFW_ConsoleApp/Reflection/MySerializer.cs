using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace Reflection
{
    public static class MySerializer<T> 
        where T : new()
    {

        public static string Serialize(T serializableItem)
        {
            var propList = typeof(T).GetProperties();

            string result = string.Empty;

            foreach (var prop in propList)
            {
                result += prop.Name + ":" + prop.GetValue(serializableItem) + ";";
            }

            return result;
        }

        public static T Deserialize(string serializedItem)
        {
            var propList = typeof (T).GetProperties().ToList();

            T result = new T();

            while (serializedItem.Length > 0)
            {
                int separatorIndex = serializedItem.IndexOf(';');
                string propNameValue = serializedItem.Substring(0, separatorIndex);
                serializedItem = serializedItem.Substring(separatorIndex + 1, serializedItem.Length - separatorIndex - 1);

                separatorIndex = propNameValue.IndexOf(":");
                string propName = propNameValue.Substring(0, separatorIndex);
                string value = propNameValue.Substring(separatorIndex + 1);

                var currentProp = propList.FirstOrDefault(x => x.Name == propName);
                propList.Remove(currentProp);
                
                currentProp.SetValue(result, Convert.ChangeType(value, currentProp.PropertyType));
            }

            return result;
        }

        public static void SerializeToFile(string filePath, T serializedItem)
        {
            File.WriteAllText(filePath, Serialize(serializedItem)); 
        }

        public static T DeserializeFromFile(string filePath)
        {
            return Deserialize(File.ReadAllText(filePath));
        }
    }
}
