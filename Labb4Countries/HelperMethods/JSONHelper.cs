using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Labb4Countries
{
    public class JsonHelper<T>
    {
        public T Type { get; private set; }

        public void Deserialize(string json)
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{json}");
            using (var reader = new StreamReader(stream))
            {
                Type = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }
    }
}