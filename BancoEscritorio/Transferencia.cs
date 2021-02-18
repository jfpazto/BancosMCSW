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
    public partial class Transferencia : Form
    {
        private Movimientos transaccion;
        private consumiendo so;
        private Cliente cliente;
        private string cuentaSale;
        public Transferencia(int id,string nombre,string apellido,string saldo,DateTime fecha,string cuenta,string clave,string rol,string cedula,Cliente cliente)
        {
            
            InitializeComponent();
            this.cliente = cliente;
            this.cuentaSale = cuenta;
            this.consumeUsuarios(id, nombre, apellido, saldo, fecha, cuenta, clave, rol, cedula);

        }
        private void consumeMovimientos(DateTime fecha, string estado, string mensaje, string monto, string cuenta)
        {
            transaccion = new Movimientos()
            {

                fecha = fecha,
                estado = estado,
                mensaje = mensaje,
                monto = monto,
                cuenta = cuenta,
            };
        }
        private void realizaTransaccion()
        {
            this.consumeMovimientos(DateTime.Today, "Finalizada", "Transaccion", txt_valor.Text, this.cuentaSale);
            string url = "http://localhost:65036/api/Movimientos/Insert";
            string result = postTransaccion(url, this.transaccion);
        }
        private void consumeUsuarios(int id, string nombre, string apellido, string saldo, DateTime fecha, string cuenta, string clave, string rol, string cedula)
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
                cedula = cedula



            };
        }

        private void Transferencia_Load(object sender, EventArgs e)
        {

        }
        public static string GetPost(string url, consumiendo so)
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
        private void traeNuevo()
        {
            string url = "http://localhost:65036/api/Usuarios/LCuenta?dto="+txt_numcuenta.Text;

            //string result = GetPost(url);

            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            //m[0].nombre;
            foreach (var i in m)
            {
                int id = System.Convert.ToInt32(i.id);
                string nombre = System.Convert.ToString(i.nombre);
                string apellido = System.Convert.ToString(i.apellido);
                string saldo = System.Convert.ToString(i.saldo);
                DateTime fecha = System.Convert.ToDateTime(i.fecha);
                string cuenta = System.Convert.ToString(i.cuenta);
                string clave = System.Convert.ToString(i.clave);
                string rol = System.Convert.ToString(i.rol);
                string cedula = System.Convert.ToString(i.cedula);
                
                consumeUsuarios(id, nombre, apellido, saldo, fecha, cuenta, clave, rol, cedula);


            }
        }
        private void put() {
            string url = "http://localhost:65036/api/Usuarios/Actualizar";
            string result = GetPost(url, this.so);
        }
        public static string postTransaccion(string url, Movimientos movim)
        {
            string result = "";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "post";
            webRequest.ContentType = "application/json;charset=UTF-8";
            using (var osw = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(movim, Formatting.Indented);
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
            

            cliente.MdiParent = this.MdiParent;
            int operacion = System.Convert.ToInt32(so.saldo) - System.Convert.ToInt32(txt_valor.Text);
            if (operacion > 0)
            {
                
                so.saldo = System.Convert.ToString(operacion);
                this.put();
                this.traeNuevo();
                int operacion2 = System.Convert.ToInt32(so.saldo) + System.Convert.ToInt32(txt_valor.Text);
                
                so.saldo = System.Convert.ToString(operacion2);
                this.put();
                this.realizaTransaccion();
                //cliente.Close();
                //cliente.Refresca();
                MessageBox.Show("Transaccion Exitosa");

            }
            else {


                //cliente.Close();
                //cliente.Show();
                MessageBox.Show("Fondos insuficientes");
            }
            txt_numcuenta.Text = "";
            txt_valor.Text = "";











        }
    }
}
