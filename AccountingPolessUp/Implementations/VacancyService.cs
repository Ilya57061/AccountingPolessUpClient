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
    public class VacancyService
    {
        private readonly WebClient _webClient;
        public VacancyService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Vacancy> Get()
        {
            var json = _webClient.DownloadString("GetVacancy");
            var Info = JsonConvert.DeserializeObject<List<Vacancy>>(json);
            if (Info is null) throw new Exception("Vacancy - null");
            else return Info;
        }
        public List<Vacancy> Get(int stagesId)
        {
            var reqparm = new NameValueCollection
            {
                ["stagesId"] = $"{stagesId}"
            };
            var response = _webClient.UploadValues("GetVacancyForStagesId", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var Info = JsonConvert.DeserializeObject<List<Vacancy>>(responseString);
            if (Info is null) throw new Exception("Vacancy by ForStagesId - null");
            else return Info;
        }

        public void Create(Vacancy model)
        {
            var reqparm = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["Descriptions"] = $"{model.Descriptions}",
                ["Responsibilities"] = $"{model.Responsibilities}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["Budget"] = $"{model.Budget}",
                ["RatingCoefficient"] = $"{model.RatingCoefficient}",
                ["StagesOfProjectId"] = $"{model.StagesOfProjectId}",
                ["isOpened"] = $"{model.isOpened}"
            };
            _webClient.UploadValues("CreateVacancy", "POST", reqparm);
        }

        public void Update(Vacancy model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Name"] = $"{model.Name}",
                ["Descriptions"] = $"{model.Descriptions}",
                ["Responsibilities"] = $"{model.Responsibilities}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["Budget"] = $"{model.Budget}",
                ["RatingCoefficient"] = $"{model.RatingCoefficient}",
                ["StagesOfProjectId"] = $"{model.StagesOfProjectId}",
                ["isOpened"] = $"{model.isOpened}"
            };
            _webClient.UploadValues("UpdateVacancy", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteVacancy", "DELETE", reqparm);
        }
        public List<Vacancy> GetFiltered(VacancyFilter model)
        {
            var reqparm = new NameValueCollection
            {
                ["Vacancy"] = $"{model.Vacancy}",
                ["Project"] = $"{model.Project}",
                ["DateYear"] = $"{model.DateYear}",
                ["DateFrom"] = $"{model.DateFrom}",
                ["DateTo"] = $"{model.DateTo}",
                ["Status"] = $"{model.Status}"
            };
            var response = _webClient.UploadValues("GetFiltredVacancy", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var vacancy = JsonConvert.DeserializeObject<List<Vacancy>>(responseString);
            if (vacancy is null) throw new Exception("vacancy - null");
            else return vacancy;
        }
    }
}