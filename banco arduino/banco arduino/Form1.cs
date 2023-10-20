using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data; // Biblioteca da conexão do SQL.
using MySql.Data.MySqlClient; // Biblioteca da conexão do SQL.
namespace banco_arduino
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }

        monitoramento m = new monitoramento();
        private void timer1_Tick(object sender, EventArgs e)
        {
            SerialPort port = new SerialPort("COM4", 9600);
            string valor_arduino;
            port.Open();
            string porta = port.ReadLine();

            valor_arduino = porta.ToString();
            
            m._valor = int.Parse(valor_arduino);
            label1.Text = m._valor.ToString();
           

            

            port.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.inserir();
            label1.Text = m._valor.ToString();
        }
    }
}
                /*
          m._valor = porta;
                m.inserir();
                consultar();
            }
            catch
            {

            }

        }
        public void consultar()
        {
          
            MySqlConnection conn = null;
            string strConn = @"Server=localhost;Database=teste;Uid=root;Pwd='';Connect Timeout=30;";
            conn = new MySqlConnection(strConn);
            conn.Open();
            string mSQL = "select valor from monitoramento order by codigo desc limit 1 ";
            MySqlCommand cmd = new MySqlCommand(mSQL, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            int registro;
            registro = count;
            label1.Text = registro.ToString();

        }

    }
                */
            
            
    
