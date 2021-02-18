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
    public partial class Form1 : Form
    {
        int id;
        string nombre;
        string apellido;
        string saldo;
        DateTime fecha;
        string cuenta;
        string clave;
        string rol;
        string celular;
        consumiendo so;
        public Form1()
        {
            InitializeComponent();

        }
        public void getUsuarios()
        {
            string url = "http://localhost:65036/api/Usuarios/listar?dto=" + txt_nombre.Text;

            //string result = GetPost(url);
            try {
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);
                //m[0].nombre;
                foreach (var i in m)
                {
                    id = System.Convert.ToInt32(i.id);
                    nombre = System.Convert.ToString(i.nombre);
                    apellido = System.Convert.ToString(i.apellido);
                    saldo = System.Convert.ToString(i.saldo);
                    fecha = System.Convert.ToDateTime(i.fecha);
                    cuenta = System.Convert.ToString(i.cuenta);
                    clave = System.Convert.ToString(i.clave);
                    rol = System.Convert.ToString(i.rol);
                    celular = System.Convert.ToString(i.cedula);
                }
                consumeUsuarios(id, nombre, apellido, saldo, fecha, cuenta, clave, rol, celular);
            }
            catch{
                MessageBox.Show("Datos Invalidos");
            }

        }
        private void consumeUsuarios(int id, string nombre, string apellido, string saldo, DateTime fecha, string cuenta, string clave, string rol, string celular)
        {
            so = new consumiendo()
            {

                id = id,
                nombre = nombre,
                apellido = apellido,
                saldo = saldo,
                fecha = System.Convert.ToDateTime(fecha),
                cuenta = cuenta,
                clave = clave,
                rol = rol,
                cedula = celular



            };
        }
        public static string putClave(string url, consumiendo so)
        {


            string result = "";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "put";
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
        private void button1_Click(object sender, EventArgs e)
        {
            Registro registro;
            Auditor auditor;
            Cliente cliente;
            
            
            
           

            string url = "http://localhost:65036/api/Usuarios/Login?dto="+txt_nombre.Text;
            var json = new WebClient().DownloadString(url);

            string urlRol = "http://localhost:65036/api/Usuarios/Roles?dto=" + txt_nombre.Text;
            var rol = new WebClient().DownloadString(urlRol);
            
            if (json == txt_clave.Text)
            {
                if (System.Convert.ToString(rol) == "Cliente")
                {
                    cliente = new Cliente(txt_nombre.Text);
                    cliente.MdiParent = this.MdiParent;
                    cliente.Show();
                    
                }
                else if (System.Convert.ToString(rol) == "Auditor")
                {
                    auditor= new Auditor();
                    auditor.MdiParent = this.MdiParent;
                    auditor.Show();
                    //registro.Show();
                }
                else if (System.Convert.ToString(rol) == "Administrador")
                {
                    registro = new Registro();
                    registro.MdiParent = this.MdiParent;
                    registro.Show();
                    //registro.Show();
                }






            }
            //string result = GetPost(url);


            //dynamic m = JsonConvert.DeserializeObject(json);
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.getUsuarios();
            so.clave = txt_clave.Text;
            string url = "http://localhost:65036/api/Usuarios/Actualizar";
            string result = putClave(url, this.so);
            
        }
    }
}
