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
                Tempo previsao = new Tempo();
                previsao.Title = (string)resultado["name"];
                previsao.Temperature = (string)resultado["main"]["temp"] + "C";
                previsao.Wind = (string)resultado["wind"]["speed"] + "mph";
                previsao.Humidity = (string)resultado["main"]["humidity"] + "%";
                previsao.Visibility = (string)resultado["weather"][0]["main"];
                DateTime time = new DateTime (1970,1, 1,0,0,0,0);
                DateTime sunrise = time.AddSeconds((double)resultado["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)resultado["sys"]["sunset"]);
                previsao.Sunrise = String.Format("{0: d/MM/yyyy HH:mm:ss}", sunrise);
                previsao.Sunset = String.Format("{0: d/MM/yyyy HH:mm:ss}", sunset);
                return previsao;
            }
            else
            {
                return null;
            }

      }

        

    }
}
