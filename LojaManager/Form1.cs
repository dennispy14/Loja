using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja.Classes;

namespace LojaManager
{
    public partial class Form1 : Form
    {
        BindingSource dados = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dados.DataSource = Cliente.Todos();
            dataGridView1.DataSource = dados;

            txtCodigo.DataBindings.Add("Text", dados, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", dados, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTipo.DataBindings.Add("Text", dados, "Tipo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataCadastro.DataBindings.Add("Text", dados, "DataCadastro", true, DataSourceUpdateMode.OnPropertyChanged);
        }
                           

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtDataCadastro.Checked)
                MessageBox.Show("DADOS NÃO GRAVADOS! \nO Capo data não pode estar em branco!");
            else
                ((Cliente)dados.Current).Gravar();            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dados.Add(new Cliente());
            dados.MoveLast();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Cliente)dados.Current).Apagar();
        }

       
    }
}
