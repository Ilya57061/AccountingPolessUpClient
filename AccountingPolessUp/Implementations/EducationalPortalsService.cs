using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{
    public class EducationalPortalsService
    {
        private readonly WebClient _webClient;
        public EducationalPortalsService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<EducationalPortals> Get()
        {
            var json = _webClient.DownloadString("GetEducationalPortals");
            var info = JsonConvert.DeserializeObject<List<EducationalPortals>>(json);
            if (info is null) throw new Exception("EducationalPortals - null");
            else return info;
        }

        public void Create(EducationalPortals model)
        {
            var reqparm = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["DepartmentId"] = $"{model.DepartmentId}",
                ["Description"] = $"{model.Description}",
                ["Link"] = $"{model.Link}"
            };
            _webClient.UploadValues("CreateEducationalPortals", "POST", reqparm);
        }

        public void Update(EducationalPortals model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Name"] = $"{model.Name}",
                ["DepartmentId"] = $"{model.DepartmentId}",
                ["Description"] = $"{model.Description}",
                ["Link"] = $"{model.Link}"
            };
            _webClient.UploadValues("UpdateEducationalPortals", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["Id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteEducationalPortals", "DELETE", reqparm);
        }
        public List<EducationalPortals> GetFiltered(EducationalPortalsFilter model)
        {
            var reqparm = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["Department"] = $"{model.Department}"
            };
            var response = _webClient.UploadValues("GetFiltredEducationalPortals", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var educationalPortals = JsonConvert.DeserializeObject<List<EducationalPortals>>(responseString);
            if (educationalPortals is null) throw new Exception("EducationalPortals - null");
            else return educationalPortals;
        }
    }
}
