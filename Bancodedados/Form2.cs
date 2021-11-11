using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bancodedados
{
    public partial class Form2 : Form
    {
        Form1 fm1;
        
        public Form2(Form1 f1)
        {
            fm1 = f1;
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtNome.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length == 0)
            {
                MessageBox.Show("Nome não pode ser Vazio");
                txtNome.Select();
                return;
            }
            
            fm1.Incluir(txtNome.Text, txtFone.Text, txtdata.Text);
            MessageBox.Show(fm1.mensagem);
            fm1.ListarTudo();
            //fm_principal.dataGridView1.DataSource = conex.ListarTudo();
            this.Close();
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            
            fm1.Alterar(txtId.Text, txtNome.Text, txtFone.Text, txtdata.Text);
            MessageBox.Show(fm1.mensagem);
            fm1.ListarTudo();
            
            fm1.dataGridView1.CurrentCell = fm1.dataGridView1.Rows[fm1.idxGride].Cells[0];
            this.Close();
        }
    }
}
