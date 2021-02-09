using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ControleOrcamentoBAL
{
    public partial class frm_MDI_Principal : Form
    { 
        public frm_MDI_Principal()
        {
            InitializeComponent();
        }

        private void frm_MDI_Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastroDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente formCli = new frmCliente();
            formCli.Show();
        }

        private void cadastroDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto formProd = new frmProduto();
            formProd.Show();
        }

        private void cadastroDeOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrcamento formOrc = new frmOrcamento();
            formOrc.Show();
        }

        
    }
}
