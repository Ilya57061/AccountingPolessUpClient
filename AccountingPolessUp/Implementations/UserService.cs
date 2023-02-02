using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public class UserService
    {
        public List<User> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetUsers";
                var json = web.DownloadString(url);
                List<User> Info = JsonConvert.DeserializeObject<List<User>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public List<User> Get(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/idUser?id={id}";
                var json = web.DownloadString(url);
                List<User> Info = JsonConvert.DeserializeObject<List<User>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public List<User> Get(string login)
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/loginUser?login={login}";
                var json = web.DownloadString(url);
                List<User> Info = JsonConvert.DeserializeObject<List<User>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(User model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Login", $"{model.Login}");
                reqparm.Add("Password", $"{model.Password}");
                reqparm.Add("isAdmin", $"{model.IsAdmin}");
                reqparm.Add("isGlobalPM", $"{model.isGlobalPM}");
                web.UploadValues("https://localhost:7273/CreateUser", "POST", reqparm);
            }
        }
        public void Update(User model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Login", $"{model.Login}");
                reqparm.Add("Password", $"{model.Password}");
                reqparm.Add("isAdmin", $"{model.IsAdmin}");
                reqparm.Add("isGlobalPM", $"{model.isGlobalPM}");
                web.UploadValues("https://localhost:7273/UpdateUser", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeletUser", "DELETE", reqparm);
            }
        }
    }
}
