using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AccountingPolessUp.Implementations
{
    public class ParticipantsService
    {
        private readonly WebClient _webClient;
        public ParticipantsService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:5001/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Participants> Get()
        {
            var json = _webClient.DownloadString("GetParticipants");
            var Info = JsonConvert.DeserializeObject<List<Participants>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public Participants GetByUser(int userId)
        {
            var reqparm = new NameValueCollection
            {
                ["userId"] = $"{userId}"
            };
            var response = _webClient.UploadValues("ParticipantByUser", "POST", reqparm);
            var responseString = Encoding.Default.GetString(response);
            Participants participants = JsonConvert.DeserializeObject<Participants>(responseString);
            return participants;
        }

        public List<Participants> Get(int id)
        {
            var url = $"Get?id={id}";
            var json = _webClient.DownloadString(url);
            var Info = JsonConvert.DeserializeObject<List<Participants>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public void Create(Participants model)
        {
            var reqparm = new NameValueCollection
            {
                ["IndividualsId"] = $"{model.IndividualsId}",
                ["UserId"] = $"{model.UserId}",
                ["DateEntry"] = $"{model.DateEntry}",
                ["DateExit"] = $"{model.DateExit}",
                ["Mmr"] = $"{model.Mmr}",
                ["Status"] = $"{model.Status}",
                ["Github"] = $"{model.GitHub}",
            };
            _webClient.UploadValues("CreateParticipant", "POST", reqparm);
        }

        public void Update(Participants model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["IndividualsId"] = $"{model.IndividualsId}",
                ["UserId"] = $"{model.UserId}",
                ["DateEntry"] = $"{model.DateEntry}",
                ["DateExit"] = $"{model.DateExit}",
                ["Mmr"] = $"{model.Mmr}",
                ["Status"] = $"{model.Status}",
                ["Github"] = $"{model.GitHub}",
            };
            _webClient.UploadValues("UpdateParticipant", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteParticipant", "DELETE", reqparm);
        }
        public Participants GetByParticipantName(string name)
        {
            var values = new NameValueCollection { ["name"] = name };
            var response = _webClient.UploadValues("GetByIndividualsFIO", "PUT", values);
            var responseString = Encoding.Default.GetString(response);
            Participants participants = JsonConvert.DeserializeObject<Participants>(responseString);
            return participants;
        }
    }
}
