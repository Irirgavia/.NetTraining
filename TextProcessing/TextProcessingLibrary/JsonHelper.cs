namespace TextProcessingLibrary
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;

    public static class JsonHelper
    {
        public static void Serialize(object json, string file, Type type)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(type);

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, json);
            }
        }

        public static Type Deserialize(string file, Type type)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(type);
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                return (Type)jsonFormatter.ReadObject(fs);
            }
        }
    }
}
