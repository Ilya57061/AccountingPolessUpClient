using AccountingPolessUp.Configurations;
using AccountingPolessUp.Helpers;
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
    public class EmploymentService
    {
        private readonly WebClient _webClient;

        public EmploymentService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Employment> Get()
        {
            try
            {
                var json = _webClient.DownloadString("GetEmployments");
                var employments = JsonConvert.DeserializeObject<List<Employment>>(json);
                if (employments == null) throw new Exception("employments - null");
                return employments;
            }
            catch (Exception)
            {

                return null;
            }
        
        }

        public Employment GetByParticipants(int participantsId)
        {
            try
            {
                var values = new NameValueCollection { ["ParticipantsId"] = participantsId.ToString() };
                var response = _webClient.UploadValues("GetByParticipants", "POST", values);
                var responseString = Encoding.Default.GetString(response);
                var employment = JsonConvert.DeserializeObject<Employment>(responseString);
                if (employment == null) throw new Exception("employment - null");
                return employment;
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public void Create(Employment model)
        {
            var values = new NameValueCollection
            {
                ["DateStart"] = model.DateStart.ToString(),
                ["DateEnd"] = model.DateEnd.ToString(),
                ["Status"] = model.Status.ToString(),
                ["StatusDescription"] = model.StatusDescription,
                ["IdMentor"] = model.IdMentor.ToString(),
                ["ParticipantsId"] = model.ParticipantsId.ToString(),
                ["PositionId"] = model.PositionId.ToString()
            };
            _webClient.UploadValues("CreateEmployment", "POST", values);
        }

        public void Update(Employment model)
        {
            var values = new NameValueCollection
            {
                ["id"] = model.Id.ToString(),
                ["DateStart"] = model.DateStart.ToString(),
                ["DateEnd"] = model.DateEnd.ToString(),
                ["Status"] = model.Status.ToString(),
                ["StatusDescription"] = model.StatusDescription,
                ["IdMentor"] = model.IdMentor.ToString(),
                ["ParticipantsId"] = model.ParticipantsId.ToString(),
                ["PositionId"] = model.PositionId.ToString()
            };
            _webClient.UploadValues("UpdateEmployment", "PUT", values);
        }

        public void Delete(int id)
        {
            try
            {
                var values = new NameValueCollection { ["id"] = id.ToString() };
                _webClient.UploadValues("DeleteEmployment", "DELETE", values);
            }
            catch (Exception)
            {
            }
        }
    }
}
