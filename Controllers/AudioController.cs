using System;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace AspNetTextAudioServer.Controllers
{
    public class AudioController : Controller
    {
        /// <summary>
        /// Retorna o arquivo de áudio WAV para streaming
        /// </summary>
        /// <returns>Arquivo WAV</returns>
        [HttpGet]
        public ActionResult GetAudio()
        {
            try
            {
                string audioFilePath = ConfigurationManager.AppSettings["AudioFilePath"];
                string fullPath = Server.MapPath(audioFilePath);

                if (!System.IO.File.Exists(fullPath))
                {
                    return HttpNotFound();
                }

                // Retorna o arquivo com o MIME type correto
                return File(fullPath, "audio/wav");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, "Erro ao obter áudio: " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna informações sobre o arquivo de áudio
        /// </summary>
        /// <returns>JSON com informações</returns>
        [HttpGet]
        public JsonResult GetAudioInfo()
        {
            try
            {
                string audioFilePath = ConfigurationManager.AppSettings["AudioFilePath"];
                string fullPath = Server.MapPath(audioFilePath);

                if (!System.IO.File.Exists(fullPath))
                {
                    return Json(new 
                    { 
                        success = false, 
                        message = "Arquivo de áudio não encontrado"
                    }, JsonRequestBehavior.AllowGet);
                }

                FileInfo fileInfo = new FileInfo(fullPath);

                return Json(new 
                { 
                    success = true, 
                    message = "Informações obtidas com sucesso",
                    fileName = fileInfo.Name,
                    fileSize = fileInfo.Length,
                    createdDate = fileInfo.CreationTime
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new 
                { 
                    success = false, 
                    message = "Erro ao obter informações: " + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}