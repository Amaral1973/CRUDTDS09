using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_POO2
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> cli = cliente.listacliente();
            dgvClientes.DataSource = cli;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Inserir(txtNome.Text, txtCelular.Text, txtEmail.Text, txtCidade.Text);
            MessageBox.Show("Cliente cadastrado com sucesso!!");
            List<Cliente> cli = cliente.listacliente();
            dgvClientes.DataSource = cli;
            txtNome.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtCidade.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt16(txtId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Localiza(Id);
            txtNome.Text = cliente.nome;
            txtCelular.Text = cliente.celular;
            txtEmail.Text = cliente.email;
            txtCidade.Text = cliente.cidade;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt16(txtId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Atualizar(Id, txtNome.Text, txtCelular.Text, txtEmail.Text, txtCidade.Text);
            MessageBox.Show("Cliente atualizado com sucesso!!");
            List<Cliente> cli = cliente.listacliente();
            dgvClientes.DataSource = cli;
            txtNome.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtCidade.Text = "";
            txtId.Text = "";
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Excluir(Id);
            MessageBox.Show("Cliente excluído com sucesso!!");
            List<Cliente> cli = cliente.listacliente();
            dgvClientes.DataSource = cli;
            txtNome.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtCidade.Text = "";
            txtId.Text = "";
        }
    }
}
