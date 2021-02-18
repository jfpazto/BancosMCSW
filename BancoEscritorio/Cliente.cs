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
    public partial class Cliente : Form
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
        string cedula;
        public Cliente(string cedula)
        {
            this.cedula = cedula;
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            string url = "http://localhost:65036/api/Usuarios/listar?dto="+cedula;

            //string result = GetPost(url);

            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            //m[0].nombre;
            foreach (var i in m)
            {
                id = System.Convert.ToInt32(i.id);
                nombre = System.Convert.ToString(i.nombre);
                apellido = System.Convert.ToString(i.apellido);
                saldo= System.Convert.ToString(i.saldo);
                fecha = System.Convert.ToDateTime(i.fecha);
                cuenta = System.Convert.ToString(i.cuenta);
                clave = System.Convert.ToString(i.clave);
                rol = System.Convert.ToString(i.rol);
                celular = System.Convert.ToString(i.celular);
                lb_nombre.Text = System.Convert.ToString(i.nombre);
                lb_saldo.Text= System.Convert.ToString(i.saldo);
               
            }
            
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            Transferencia cliente = new Transferencia(id, nombre, apellido, saldo, fecha, cuenta, clave, rol, cedula,this);

            cliente.MdiParent = this.MdiParent;
            cliente.Show();

        }
        public void Refresca()
        {
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
