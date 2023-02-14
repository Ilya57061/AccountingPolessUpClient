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
                BaseAddress = "https://localhost:5001/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Employment> Get()
        {
            var json = _webClient.DownloadString("GetEmployments");
            var info = JsonConvert.DeserializeObject<List<Employment>>(json);
            if (info == null) throw new Exception("info - null");
            return info;
        }

        public Employment GetByParticipants(int participantsId)
        {
            var values = new NameValueCollection { ["ParticipantsId"] = participantsId.ToString() };
            var response = _webClient.UploadValues("GetByParticipants", "POST", values);
            var responseString = Encoding.Default.GetString(response);
            var employment = JsonConvert.DeserializeObject<Employment>(responseString);
            return employment;
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
