using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using MySql.Data; // Biblioteca da conexão do SQL.
using MySql.Data.MySqlClient; // Biblioteca da conexão do SQL.
namespace banco_arduino
{
    class monitoramento : conexao
    {
            
            private int codigo;
            private int valor;
            public int _codigo
            {
                get
                {
                    return codigo;
                }
                set
                {
                    codigo = value;
                }
            }
            public int _valor
            {
                get
                {
                    return valor;
                }
                set
                {
                    valor = value;
                }
            }
            

            public void inserir()
            {
                string query = "INSERT INTO all_info (valor) VALUES ('" + _valor + "')";
                if (this.abrirconexao() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);
                    cmd.ExecuteNonQuery();
                    this.fecharconexao();
                }
            }
        }
}
