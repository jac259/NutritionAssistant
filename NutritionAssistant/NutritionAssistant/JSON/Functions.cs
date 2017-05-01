using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class Functions
    {
        const string newUserName = "New user...";

        public static string GetFilepath(string _filename)
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + '\\' + _filename;
        }

        public static List<User> GetUsers(string filepath)
        {
            if (!File.Exists(filepath))
            {
                List<User> newUsers = new List<User>();
                WriteJSON(newUsers, filepath);
                return newUsers;
            }

            return ReadUserJSON(filepath);
        }

        public static User GetLoggedIn(List<User> _users)
        {
            int index = _users.FindIndex(x => x.logged_in == true);
            if (index == -1)
            {
                _users[0] = _users[0].SetLogin(true);
                return _users[0];
            }
            else
                return _users[index];
        }

        public static void WriteJSON(List<User> _users, string filepath)
        {
            _users.RemoveAll(x => x.name == newUserName);

            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, _users);
            }
        }

        public static void WriteJSON(List<Food> _foods, string filepath)
        {
            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, _foods);
            }
        }

        public static List<User> ReadUserJSON(string filepath)
        {
            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                return (List<User>)js.Deserialize(file, typeof(List<User>));
            }
        }

        public static List<Food> ReadFoodJSON(string filepath)
        {
            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                return (List<Food>)js.Deserialize(file, typeof(List<Food>));
            }
        }
    }
}
