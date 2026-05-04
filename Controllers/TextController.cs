using System;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace AspNetTextAudioServer.Controllers
{
    public class TextController : Controller
    {
        /// <summary>
        /// Obtém o conteúdo do arquivo de texto
        /// </summary>
        /// <returns>JSON com o texto</returns>
        [HttpGet]
        public JsonResult GetText()
        {
            try
            {
                string textFilePath = ConfigurationManager.AppSettings["TextFilePath"];
                string fullPath = Server.MapPath(textFilePath);

                if (!System.IO.File.Exists(fullPath))
                {
                    return Json(new 
                    { 
                        success = false, 
                        message = "Arquivo de texto não encontrado",
                        data = ""
                    }, JsonRequestBehavior.AllowGet);
                }

                string textContent = System.IO.File.ReadAllText(fullPath, System.Text.Encoding.UTF8);

                return Json(new 
                { 
                    success = true, 
                    message = "Texto lido com sucesso",
                    data = textContent
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new 
                { 
                    success = false, 
                    message = "Erro ao ler arquivo: " + ex.Message,
                    data = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}