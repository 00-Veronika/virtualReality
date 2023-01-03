using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagement.Extensions
{
    public static class SessionExtensions
    {
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

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string jsonData = session.GetString(key);

            if (string.IsNullOrEmpty(jsonData))
            {
                return null;
            }
            return JsonSerializer.Deserialize<T>(jsonData);

        }
    }
}
