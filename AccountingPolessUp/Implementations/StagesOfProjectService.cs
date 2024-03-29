﻿using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{
    public class StagesOfProjectService
    {
        private readonly WebClient _webClient;
        public StagesOfProjectService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<StagesOfProject> Get()
        {
            var json = _webClient.DownloadString("GetStagesOfProject");
            var Info = JsonConvert.DeserializeObject<List<StagesOfProject>>(json);
            if (Info is null) throw new Exception("StagesOfProjectForProject - null");
            else return Info;
        }
        public List<StagesOfProject> Get(int projectId)
        {
            var reqparm = new NameValueCollection
            {
                ["projectId"] = $"{projectId}"
            };
            var response = _webClient.UploadValues("GetStagesOfProjectForProjectId", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var Info = JsonConvert.DeserializeObject<List<StagesOfProject>>(responseString);
            if (Info is null) throw new Exception("StagesOfProjectForProject by Id- null");
            else return Info;
        }

        public void Create(StagesOfProject model)
        {
            var reqparm = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["ProjectId"] = $"{model.ProjectId}",
                ["Status"] = $"{model.Status}"
            };
            _webClient.UploadValues("CreateStagesOfProject", "POST", reqparm);
        }

        public void Update(StagesOfProject model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["Status"] = $"{model.Status}",
                ["ProjectId"] = $"{model.ProjectId}"
            };
            _webClient.UploadValues("UpdateStagesOfProject", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };

                _webClient.UploadValues("DeleteStagesOfProject", "DELETE", reqparm);
            }
            catch (Exception)
            {
            }

        }
    }

}
