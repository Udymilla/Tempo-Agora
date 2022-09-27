using System;
using System.Collections.Generic;
using System.Text;


using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppTempo.Model;

namespace AppTempo.Services
{
    internal class DataServices
    {
      public static async Task<Tempo> GetPrevisaoDoTempo (string cidade)
        {
            string appId = "";

            string queryString = "" + cidade + "&units=metric" + "&appid=" + appId;

            dynamic resultado = await getDataFromServices(queryString).ConfigureAwait(false);

            if (resultado["weather"] != null)
            {

            }

        }

        

    }
}
