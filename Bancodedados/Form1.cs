using Npgsql;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bancodedados
{
    public partial class Form1 : Form
    {
        // versao 1.0.4

        Form2 fm2;
        public int idxGride { get; set; }

        string connectString = "Server=localhost;Port=5432;User Id=postgres;Password=testeteste;Database=postgres";
        public string mensagem = "";
        NpgsqlConnection cnn;
        NpgsqlCommand cmd;

        public Form1()
        {
            cnn = new NpgsqlConnection(connectString);
            InitializeComponent();
            fm2 = new Form2(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (IsAppAlreadyRunning())
            {
                MessageBox.Show("O aplicativo já está em execução!");
                Process.GetCurrentProcess().Kill();
            }

            if (!CheckTabela())
            {
                DialogResult resp = MessageBox.Show("Tabela Cadastro Não Existe, Deseja Criar uma?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                    CriaTabela();

            }

            // lista todo conteudo da tabela na grid
            ListarTudo();
            String texto;
            String pathfile = @"c:\zagaomaster\configuracao.txt";
            //string diretorio = Directory.GetCurrentDirectory();
            //string dire = diretorio.getpa
            //txtbusca.Text = diretorio;

            if (!File.Exists(pathfile))
            {
                if (!Directory.Exists(pathfile))
                {
                    MessageBox.Show("Diretorio não existe, Foi criado 'zagaomaster'. Aplicativo será Reiniciado.");
                    Directory.CreateDirectory(@"c:\zagaomaster");
                    Application.Restart();
                }

                StreamWriter sw = new StreamWriter(pathfile);
                sw.WriteLine("Sistema De Banco de Dados");
                sw.WriteLine("Versao 1.0.5");
                sw.Close();

            }
            else
            {
                StreamReader sr = new StreamReader(pathfile);
                String linha = sr.ReadLine();
                texto = linha;
                linha = sr.ReadLine();
                texto += " " + linha;
                sr.Close();
                this.Text = texto;
            }


        }


        bool CheckTabela()
        {
            string sql = "select exists(select * from information_schema.tables where table_name='cadastro')";
            bool statos = false;
            try
            {
                cnn = new NpgsqlConnection(connectString);
                cmd = new NpgsqlCommand(sql, cnn);
                cnn.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //MessageBox.Show(dr[0].ToString());
                    if (dr[0].ToString() == "True")
                    {
                        statos = true;
                    }

                }
                dr.Close();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados," + ex.Message);

            }
            return statos;
        }

        public void CriaTabela()
        {
            string sql = "create table cadastro (" +
                "id serial not null," +
                "nome varchar(30) not null," +
                "fone varchar(13)," +
                "datacadastro timestamp without time zone," +
                "primary key (id));" +
                "create index idx_nome on cadastro (nome)";
            try
            {
                cnn = new NpgsqlConnection(connectString);
                cmd = new NpgsqlCommand(sql, cnn);
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

        public void busca(string dado)
        {
            string sql = "select * from cadastro where nome ilike @busca"; // ILIKE busca sem importar maiuscula e minuscula, ja LIKE importa
            try
            {
                cnn = new NpgsqlConnection(connectString);
                cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@busca", dado + "%");
                cnn.Open();

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["fone"].ToString(), dr["datacadastro"].ToString());

                }
                dr.Close();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados, " + ex.Message);

            }
        }



        public void ListarTudo()
        {


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

                if (linhas < 8)
                {
                    cmd.CommandText = "select * from cadastro";
                }else
                {
                    cmd.CommandText = "select * from cadastro offset @num - 8";
                    cmd.Parameters.AddWithValue("@num", linhas);
                }
                
                
                
                dr = cmd.ExecuteReader();

                dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["fone"].ToString(), dr["datacadastro"].ToString());

                }
                dr.Close();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados, " + ex.Message);

            }
        }


        private bool IsAppAlreadyRunning()
        {
            Process currentProcess = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(currentProcess.ProcessName).Any(p => p.Id != currentProcess.Id && !p.HasExited))
            {
                return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm2.btnSalva.Enabled = true;
            fm2.btnAtualiza.Enabled = false;
            fm2.txtId.Clear();
            fm2.txtNome.Clear();
            fm2.txtFone.Clear();
            fm2.txtdata.Text = DateTime.Now.ToString();
            fm2.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            string conNome = dataGridView1.Columns[e.ColumnIndex].Name;

            if (conNome == "Colupdate")
            {
                fm2.btnAtualiza.Enabled = true;
                fm2.btnSalva.Enabled = false;
                fm2.txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                fm2.txtNome.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                fm2.txtFone.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                fm2.txtdata.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                idxGride = e.RowIndex;
                fm2.ShowDialog(this);

            }
            else if (conNome == "ColDelete")
            {
                DialogResult resp = MessageBox.Show("Tem Certeza que quer Excluir este Registro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                {
                    string indice = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Excluir(indice);
                    //MessageBox.Show(conexao.mensagem);
                    ListarTudo();
                    //dataGridView1.DataSource = conexao.ListarTudo();
                }
            }
        }

        public void Alterar(string idx, string nome, string fone, string datacad)
        {
            int idx1 = Int32.Parse(idx);
            DateTime dt = DateTime.Parse(datacad);
            string sql = "update cadastro set nome=@nome,fone=@fone, datacadastro=@datac where id=@codigo";
            cmd = new NpgsqlCommand(sql, cnn);
            try
            {
                cnn.Open();
                cmd.Parameters.AddWithValue("@codigo", idx1);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@fone", fone);
                cmd.Parameters.AddWithValue("@datac", dt);
                cmd.ExecuteNonQuery();
                cnn.Close();
                mensagem = "Atualizado com Sucesso.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro> " + ex.Message);
            }
            
            

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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados, " + ex.Message);

            }
        }

        public void Excluir(string idx)
        {
            int idx1 = Int32.Parse(idx);
            string sql = "DELETE FROM cadastro WHERE id=@codigo";
            cmd = new NpgsqlCommand(sql, cnn);
            try
            {
                cnn.Open();
                cmd.Parameters.AddWithValue("@codigo", idx1);
                cmd.ExecuteNonQuery();
                cnn.Close();
                mensagem = "Registro Excluido com Sucesso.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro> " + ex.Message);
            }
            

        }




        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (txtbusca.Text.Length == 0)
            {
                //MessageBox.Show("Nome Não pode estar Vazio");
                ListarTudo();
                txtbusca.Select();
                return;
            }

            busca(txtbusca.Text);
        }

        private void txtbusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }

            //busca(txtbusca.Text);
        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            if (txtbusca.TextLength == 0)
                ListarTudo();
            else
                busca(txtbusca.Text);
        }
    }
}
