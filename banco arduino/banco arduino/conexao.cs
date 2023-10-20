using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data; // Biblioteca da conexão do SQL.
using MySql.Data.MySqlClient; // Biblioteca da conexão do SQL.

namespace banco_arduino
{
    class conexao
    {
        public MySqlConnection conectar;
        public string servidor;
        public string database;
        public string usuario;
        public string senha;

        // Construindo a conexão

        public conexao()
        {
            inicializar();
        }

        //Inicializar conexão com o sql
        public void inicializar()
        {
            servidor = "127.0.0.1";
            database = "bdtcc";
            usuario = "root";
            senha = "";
            string conexaostring;
            conexaostring = "SERVER=" + servidor + ";" + "DATABASE=" +
            database + ";" + "UID=" + usuario + ";" + "PASSWORD=" + senha + ";";

            conectar = new MySqlConnection(conexaostring);
        }

        // Abrindo a database
        public bool abrirconexao()
        {
            try
            {
                conectar.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Não foi possível conectar.");
                        break;
                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Usuário e senha inválidos! Verifique.");
                        break;
                }
                return false;
            }
        }

        // Fechar conexão
        public bool fecharconexao()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}