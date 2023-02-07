using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public static class CreateAdmService
    {
        public static void CreateAdm()
        {
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString("https://polessu.by/polessup/RegisterAdmin");
            }
        }
    }
}
