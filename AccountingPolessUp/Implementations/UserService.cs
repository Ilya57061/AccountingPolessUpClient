﻿using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class UserService
    {
        private readonly WebClient _webClient;
        public UserService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }
        public List<User> Get()
        {
            var json = _webClient.DownloadString("GetUsers");
            var Info = JsonConvert.DeserializeObject<List<User>>(json);
            if (Info is null) throw new Exception("users - null");
            else return Info;
        }

        public List<User> Get(int id)
        {
            var json = _webClient.DownloadString($"idUser?id={id}");
            var Info = JsonConvert.DeserializeObject<List<User>>(json);
            if (Info is null) throw new Exception("user by id - null");
            else return Info;
        }

        public List<User> Get(string login)
        {
            var json = _webClient.DownloadString($"loginUser?login={login}");
            var Info = JsonConvert.DeserializeObject<List<User>>(json);
            if (Info is null) throw new Exception("User by login - null");
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
            _webClient.UploadValues("UpdatePasswordUser", "PUT", reqparm);
        }
        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeletUser", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }
        }
    }
}
