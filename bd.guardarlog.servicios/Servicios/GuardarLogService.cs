using bd.log.guardar.Inicializar;
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

                   
                    var url = "/api/LogEntries/InsertarLonEntry";
                    var uri = string.Format("{0}/{1}", AppGuardarLog.BaseAddress, url);
                    var respuesta = await cliente.PostAsync(new Uri(uri), content);

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
