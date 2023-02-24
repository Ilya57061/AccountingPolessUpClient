using AccountingPolessUp.Models;
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
    public class ProjectService
    {
        private readonly WebClient _webClient;
        public ProjectService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://polessu.by/polessup/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Project> Get()
        {
            var json = _webClient.DownloadString("GetProject");
            var Info = JsonConvert.DeserializeObject<List<Project>>(json);
            if (Info is null) throw new Exception("projects - null");
            else return Info;
        }

        public void Create(Project model)
        {
            var reqparm = new NameValueCollection
            {
                ["Fullname"] = $"{model.Fullname}",
                ["Status"] = $"{model.Status}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["Description"] = $"{model.Description}",
                ["TechnicalSpecification"] = $"{model.TechnicalSpecification}",
                ["CustomerId"] = $"{model.CustomerId}",
                ["idLocalPM"] = $"{model.idLocalPM}"
            };
            _webClient.UploadValues("CreateProject", "POST", reqparm);
        }

        public void Update(Project model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Fullname"] = $"{model.Fullname}",
                ["Status"] = $"{model.Status}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["Description"] = $"{model.Description}",
                ["TechnicalSpecification"] = $"{model.TechnicalSpecification}",
                ["CustomerId"] = $"{model.CustomerId}",
                ["idLocalPM"] = $"{model.idLocalPM}"
            };
            _webClient.UploadValues("UpdateProject", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeleteProject", "DELETE", reqparm);
            }
            catch (Exception)
            {
            }
        }
    }
    }
