using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;

namespace AccountingPolessUp.Implementations
{

    public class AuthService
    {
        private readonly WebClient _webClient;

        public AuthService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:5001/",
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public User Login(LoginDto loginModel)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["Login"] = $"{loginModel.Login}",
                    ["Password"] = $"{loginModel.Password}"
                };

                var response = _webClient.UploadValues("Login", "POST", reqparm);
                var responseString = Encoding.Default.GetString(response);
                TokenDto token = JsonConvert.DeserializeObject<TokenDto>(responseString);
                TokenManager.AccessToken = token.Token;
                return token.User;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
