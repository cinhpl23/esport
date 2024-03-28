using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace esport.Business.Services
{
    public class JsonSerializerService
    {
        public static void SerializeToFile<T>(string filePath, T data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to serialize data: {ex.Message}", ex);
            }
        }
        public static T DeserializeFromFile<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to serialize data: {ex.Message}", ex);
            }
            return default;
        }
    }
}
