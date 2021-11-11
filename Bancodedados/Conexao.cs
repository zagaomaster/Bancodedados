using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Npgsql;

namespace Bancodedados
{
    class Conexao
    {
        string connectString = "Server=localhost;Port=5432;User Id=postgres;Password=testeteste;Database=postgres";
        public string mensagem = "";
        NpgsqlConnection cnn;
        NpgsqlCommand cmd;
        //SqlConnection cnn;
        //SqlCommand cmd;

        public string propriedade { get; set; }

        public Conexao(Form1 ft)
        {
            cnn = new NpgsqlConnection(connectString);
        }
        public Conexao()
        {
            cnn = new NpgsqlConnection(connectString);
        }
        

        public void Alterar(string idx, string nome, string fone, string datacad)
        {
            int idx1 = Int32.Parse(idx);
            DateTime dt = DateTime.Parse(datacad);
            string sql = "update cadastro set nome=@nome,fone=@fone, datacadastro=@datac where id=@codigo";
            cmd = new NpgsqlCommand(sql, cnn);
            cnn.Open();
            cmd.Parameters.AddWithValue("@codigo", idx1);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@fone", fone);
            cmd.Parameters.AddWithValue("@datac", dt);
            cmd.ExecuteNonQuery();
            cnn.Close();
            mensagem = "Atualizado com Sucesso.";
            
        }

        public void Incluir(string nome, string fone, string datac)
        {
            DateTime dt = DateTime.Parse(datac);
            string sql = "insert into cadastro(nome,fone,datacadastro) values(@nome,@fone,@datacad)";
            try
            {
                //cnn = new SqlConnection(connectString);
                //cmd = new SqlCommand(sql, cnn);
                cmd = new NpgsqlCommand(sql, cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@fone", fone);
                cmd.Parameters.AddWithValue("@datacad", dt);
                cmd.ExecuteNonQuery();
                
                cnn.Close();

                mensagem = "Cadastrado com Sucesso.";

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados");
               
            }
        }

        public DataTable ListarTudo()
        {
           

            string sql = "select * from cadastro";
            try
            {
                cnn = new NpgsqlConnection(connectString);
                cmd = new NpgsqlCommand(sql, cnn);
                cnn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cnn.Close();

                return dt;
                    
                
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados");
                return null;
            }
        }
    }
}
