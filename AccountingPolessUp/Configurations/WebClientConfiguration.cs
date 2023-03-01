using AccountingPolessUp.Models;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Configurations
{
    public static class WebClientConfiguration
    {
        public const string BaseAdress = "https://polessu.by/polessup/";

        public static Encoding Encoding = Encoding.UTF8;

        public static WebHeaderCollection Headers = new WebHeaderCollection
        {
            ["Authorization"] = "Bearer " + TokenManager.AccessToken
        };
    }
}
