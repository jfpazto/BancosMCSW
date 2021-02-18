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
    public partial class Auditor : Form
    {
        public Auditor()
        {
            InitializeComponent();
        }

        private void Auditor_Load(object sender, EventArgs e)
        {
            string url = "http://localhost:65036/api/Movimientos/listar";

            //string result = GetPost(url);

            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);

            //Console.WriteLine(json);
            dataGridView1.DataSource = m;


            lb_tot.Text = System.Convert.ToString(dataGridView1.RowCount);

            int suma = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                suma = suma + System.Convert.ToInt32(row.Cells["monto"].Value);
                

            }
            lb_monto.Text = suma.ToString();
            
        }
    }
}
