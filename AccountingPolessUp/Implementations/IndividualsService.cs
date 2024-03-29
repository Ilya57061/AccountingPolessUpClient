﻿using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;


namespace AccountingPolessUp.Implementations
{
    public class IndividualsService
    {
        private readonly WebClient _webClient;

        public IndividualsService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Individuals> Get()
        {
            var json = _webClient.DownloadString("GetIndividuals");
            var Info = JsonConvert.DeserializeObject<List<Individuals>>(json);
            if (Info is null) throw new Exception("Individuals - null");
            else return Info;
        }

        public void Create(Individuals model)
        {
            var reqparm = new NameValueCollection
            {
                ["FIO"] = $"{model.FIO}",
                ["Phone"] = $"{model.Phone}",
                ["DateOfBirth"] = $"{model.DateOfBirth}",
                ["Mail"] = $"{model.Mail}",
                ["Gender"] = $"{model.Gender}",
                ["SocialNetwork"] = $"{model.SocialNetwork}"
            };
            _webClient.UploadValues("CreateIndividual", "POST", reqparm);
        }

        public void Update(Individuals model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["FIO"] = $"{model.FIO}",
                ["Phone"] = $"{model.Phone}",
                ["DateOfBirth"] = $"{model.DateOfBirth}",
                ["Mail"] = $"{model.Mail}",
                ["Gender"] = $"{model.Gender}",
                ["SocialNetwork"] = $"{model.SocialNetwork}"
            };
            _webClient.UploadValues("UpdateIndividual", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeletIndividual", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }
        }
    }
}
