using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace BancoEscritorio
{
    public partial class Registro : Form
    {
        consumiendo so;
        public Registro()
        {
            InitializeComponent();
        }
        public static string postUsuarios(string url, consumiendo so)
        {
            string result = "";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "post";
            webRequest.ContentType = "application/json;charset=UTF-8";
            using (var osw = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(so, Formatting.Indented);
                //string json = "{\"nombre\":\"juanito\"}";
                osw.Write(json);
                osw.Flush();
                osw.Close();
            }
            WebResponse oresponse = webRequest.GetResponse();
            using (var osr = new StreamReader(oresponse.GetResponseStream()))
            {
                result = osr.ReadToEnd().Trim();
            }

            return result;
        }
        private void consumeUsuarios()
        {
            so = new consumiendo()
            {

                
                nombre = txt_nombre.Text,
                apellido = txt_apellido.Text,
                saldo = txt_saldo.Text,
                fecha = DateTime.Today,
                cuenta = txt_cuenta.Text,
                clave = "",
                rol = txt_rol.Text,
                cedula = txt_cedula.Text



            };
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.consumeUsuarios();
            string url = "http://localhost:65036/api/Usuarios/Insert";
            string result = postUsuarios(url, this.so);
            MessageBox.Show("Datos Registrados");
            txt_nombre.Text ="";
            txt_apellido.Text = "";
            txt_saldo.Text = "";
            txt_cuenta.Text = "";
            txt_rol.Text = "";
            txt_cedula.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregaFondos frm_fondos = new AgregaFondos();
            frm_fondos.MdiParent = this.MdiParent;
            frm_fondos.Show();
        }
    }
}
