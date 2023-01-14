using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace virtualReality.Extensions
{
    public static class SessionExtensions
    {
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string jsonData = session.GetString(key);

            if (string.IsNullOrEmpty(jsonData))
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static void SetObject<T>(this ISession session, string key, T value) where T : class
        {
            if (value == null)
            {
                session.Remove(key);
                return;
            }

            string jsonData = JsonSerializer.Serialize(value);
            session.SetString(key, jsonData);
        }
    }
}
