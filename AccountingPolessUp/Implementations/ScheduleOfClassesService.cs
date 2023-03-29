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
    public class ScheduleOfClassesService
    {
        private readonly WebClient _webClient;
        public ScheduleOfClassesService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<ScheduleOfСlasses> Get()
        {

            try
            {
                var json = _webClient.DownloadString("GetScheduleOfСlasses");
                var Info = JsonConvert.DeserializeObject<List<ScheduleOfСlasses>>(json);
                if (Info is null) throw new Exception("ScheduleOfСlasses - null");
                else return Info;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ScheduleOfСlasses> Get(int coursesId)
        {
            var reqparm = new NameValueCollection
            {
                ["coursesId"] = $"{coursesId}"
            };
            var response = _webClient.UploadValues("GetScheduleOfClassesForCoursesId", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var Info = JsonConvert.DeserializeObject<List<ScheduleOfСlasses>>(responseString);
            if (Info is null) throw new Exception("ScheduleOfСlasses by coursId - null");
            else return Info;
        }

        public void Create(ScheduleOfСlasses model)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["Description"] = $"{model.Description}",
                    ["DateStart"] = $"{model.DateStart}",
                    ["DateEnd"] = $"{model.DateEnd}",
                    ["WorkSpaceLink"] = $"{model.WorkSpaceLink}",
                    ["TrainingCoursesId"] = $"{model.TrainingCoursesId}"
                };
                _webClient.UploadValues("CreateScheduleOfСlasses", "POST", reqparm);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Update(ScheduleOfСlasses model)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["Id"] = $"{model.Id}",
                    ["Description"] = $"{model.Description}",
                    ["DateStart"] = $"{model.DateStart}",
                    ["DateEnd"] = $"{model.DateEnd}",
                    ["WorkSpaceLink"] = $"{model.WorkSpaceLink}",
                    ["TrainingCoursesId"] = $"{model.TrainingCoursesId}"
                };
                _webClient.UploadValues("UpdateScheduleOfСlasses", "PUT", reqparm);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeleteScheduleOfСlasses", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }

        }
        public List<ScheduleOfСlasses> GetFiltered(ScheduleOfСlassesFilter model)
        {
            var reqparm = new NameValueCollection
            {
                ["Lector"] = $"{model.Lector}",
                ["DateYear"] = $"{model.DateYear}",
                ["DateFrom"] = $"{model.DateFrom}",
                ["DateTo"] = $"{model.DateTo}",
                ["Status"] = $"{model.Status}"
            };
            var response = _webClient.UploadValues("GetFiltredScheduleOfСlasses", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var scheduleOfСlasses = JsonConvert.DeserializeObject<List<ScheduleOfСlasses>>(responseString);
            if (scheduleOfСlasses is null) throw new Exception("scheduleOfСlasses - null");
            else return scheduleOfСlasses;
        }
    }
}
