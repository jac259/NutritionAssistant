using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NutritionAssistant.JSON;
using System.Reflection;

namespace NutritionAssistant
{
    class Query
    {
        const string app_Id = "2e481270";
        const string app_Key = "5f7f23a4d1e548f572bf781adb590000";

        static List<string> getFieldNames()
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

            List<string> fieldNames = typeof(Food).GetFields(bindingFlags).Select(field => field.Name).ToList();

            for(int i = 0; i < fieldNames.Count; i++)
                fieldNames[i] = fieldNames[i].Split('<', '>')[1];

            return fieldNames;
        }

        public static async Task<string> query(string queryString)
        {
            using (var client = new HttpClient())
            {

                object data = new
                {
                    appId = app_Id,
                    appKey = app_Key,
                    query = queryString,
                    fields = getFieldNames().ToArray()
                };

                var dataContent = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(dataContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync("https://api.nutritionix.com/v1_1/search", byteContent);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
    }
}
