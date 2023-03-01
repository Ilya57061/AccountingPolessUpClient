using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{

    public class AuthService
    {
        private readonly WebClient _webClient;

        public AuthService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
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
                var token = JsonConvert.DeserializeObject<TokenDto>(responseString);
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
