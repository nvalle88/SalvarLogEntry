using bd.log.guardar.ObjectTranfer;
using bd.log.guardar.Utiles;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bd.log.guardar.Servicios
{
    public static  class GuardarLogService
    {
        #region Methods

        public static async Task<Response> SaveLogEntry(LogEntryTranfer logEntryTranfer)
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    var request = JsonConvert.SerializeObject(logEntryTranfer);
                    var content = new StringContent(request, Encoding.UTF8, "application/json");

                    cliente.BaseAddress = new Uri("http://localhost:5000");
                    var url = "/api/LogEntries/InsertarLonEntry";
                    var respuesta = await cliente.PostAsync(url, content);

                    var resultado = await respuesta.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Response>(resultado);
                    return response;

                }
            }
            catch (Exception)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Error",
                };
            }

        }

        #endregion
    }
}
