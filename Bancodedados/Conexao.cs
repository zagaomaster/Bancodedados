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
        readonly string connectString = "Server=localhost;Port=5432;User Id=postgres;Password=testeteste;Database=postgres";
        public string mensagem = "";
        NpgsqlConnection cnn;
        NpgsqlCommand cmd;
        readonly Form1 fm1;

        //SqlConnection cnn;
        //SqlCommand cmd;

        public string propriedade { get; set; }

        public Conexao(Form1 ft)
        {
            cnn = new NpgsqlConnection(connectString);
            cmd = new NpgsqlCommand("", cnn);
            fm1 = ft;
        }

        public void CriaTabela()
        {
            cmd.CommandText = "create table cadastro (" +
                "id serial not null," +
                "nome varchar(30) not null," +
                "fone varchar(13)," +
                "datacadastro timestamp without time zone," +
                "primary key (id));" +
                "create index idx_nome on cadastro (nome)";
            try
            {
                cnn.Open();

                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Tabela Cadastro Criado com Sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Criar Tabela Cadastro, " + ex.Message);

            }


        }




        public void Alterar(string idx, string nome, string fone, string datacad)
        {
            int idx1 = Int32.Parse(idx);
            DateTime dt = DateTime.Parse(datacad);
            cmd.CommandText = "update cadastro set nome=@nome,fone=@fone, datacadastro=@datac where id=@codigo";
            //cmd = new NpgsqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@codigo", idx1);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@fone", fone);
            cmd.Parameters.AddWithValue("@datac", dt);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            mensagem = "Atualizado com Sucesso.";
            
        }

        public void Incluir(string nome, string fone, string datac)
        {
            DateTime dt = DateTime.Parse(datac);
            cmd.CommandText = "insert into cadastro(nome,fone,datacadastro) values(@nome,@fone,@datacad)";
            try
            {
                //cnn = new SqlConnection(connectString);
                //cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@fone", fone);
                cmd.Parameters.AddWithValue("@datacad", dt);
                cnn.Open();
                cmd.ExecuteNonQuery();
                
                cnn.Close();

                mensagem = "Cadastrado com Sucesso.";

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
               
            }
        }

        public void Excluir(string idx)
        {
            try
            {
                int idx1 = Int32.Parse(idx);
                cmd.CommandText = "DELETE FROM cadastro WHERE id=@codigo";

                cnn.Open();
                cmd.Parameters.AddWithValue("@codigo", idx1);
                cmd.ExecuteNonQuery();
                cnn.Close();
                mensagem = "Registro Excluido com Sucesso.";

            }catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            

        }


        public void busca(string dado)
        {
            cmd.CommandText = "select * from cadastro where nome ilike @busca"; // ILIKE busca sem importar maiuscula e minuscula, ja LIKE importa
            try
            {
                
                cmd.Parameters.AddWithValue("@busca", dado + "%");
                cnn.Open();

                NpgsqlDataReader dr = cmd.ExecuteReader();
                fm1.dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    fm1.dataGridView1.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["fone"].ToString(), dr["datacadastro"].ToString());

                }
                dr.Close();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);

            }
        }



        public void ListarTudo()
        {

            // lista os ultimos 8 registros

            string sql = "select count (*) from cadastro";
            try
            {
                cnn = new NpgsqlConnection(connectString);
                cmd = new NpgsqlCommand(sql, cnn);
                cnn.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                long linhas = long.Parse(dr[0].ToString());

                dr.Close();
                cmd.CommandText = "select * from cadastro offset @num - 8";
                cmd.Parameters.AddWithValue("@num", linhas);
                dr = cmd.ExecuteReader();

                fm1.dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    fm1.dataGridView1.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["fone"].ToString(), dr["datacadastro"].ToString());

                }
                dr.Close();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados, " + ex.Message);

            }
        }
    }
}
