using bd.log.guardar.ObjectTranfer;
using bd.log.guardar.Utiles;
using System;
using System.Threading.Tasks;

namespace bd.log.guardar.Interfaces
{
    public interface ICommonSecurityService
    {
       Task<Response> SaveLogEntry(LogEntryTranfer logEntryTranfer, Uri baseAddress, string url);
    }
}
