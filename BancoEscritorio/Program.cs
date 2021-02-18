using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace BancoEscritorio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           /* 
            string url = "http://localhost:65036/api/Movimientos/listar";

            //string result = GetPost(url);
            
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);

            Console.WriteLine(json);



        }
        public static string GetPost(string url)
        {
            consumiendo so = new consumiendo()
            {
                nombre = "Juanito"
            };


            string result = "";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "put";
            webRequest.ContentType = "application/json;charset=UTF-8";
            using (var osw=new StreamWriter(webRequest.GetRequestStream())) {
                string json = JsonConvert.SerializeObject(so,Formatting.Indented);
                //string json = "{\"nombre\":\"juanito\"}";
                osw.Write(json);
                osw.Flush();
                osw.Close();
            }
            WebResponse oresponse = webRequest.GetResponse();
            using (var osr=new StreamReader(oresponse.GetResponseStream()))
            {
                result = osr.ReadToEnd().Trim();
            }
            return result;*/
        }
    }
}
