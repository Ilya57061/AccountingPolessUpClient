using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public class UserService
    {
        private readonly WebClient _webClient;
        public UserService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://polessu.by/polessup/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }
        public List<User> Get()
        {
            var json = _webClient.DownloadString("GetUsers");
            var Info = JsonConvert.DeserializeObject<List<User>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public List<User> Get(int id)
        {
            var json = _webClient.DownloadString($"idUser?id={id}");
            var Info = JsonConvert.DeserializeObject<List<User>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public List<User> Get(string login)
        {
            var json = _webClient.DownloadString($"loginUser?login={login}");
            var Info = JsonConvert.DeserializeObject<List<User>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public void Create(RegisterDto model)
        {
            var reqparm = new NameValueCollection
            {
                ["Login"] = $"{model.Login}",
                ["Password"] = $"{model.Password}",
                ["RoleId"] = $"{model.RoleId}"
            };
            _webClient.UploadValues("Register", "POST", reqparm);
        }

        public void Update(User model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Login"] = $"{model.Login}",
                ["RoleId"] = $"{model.RoleId}"
            };
            _webClient.UploadValues("UpdateUser", "PUT", reqparm);
        }
        public void UpdatePassword(UpdatePasswordDto model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Password"] = $"{model.Password}",
            };
            _webClient.UploadValues("UpdateUser", "PUT", reqparm);
        }
        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteUser", "DELETE", reqparm);
        }
    }
    }
