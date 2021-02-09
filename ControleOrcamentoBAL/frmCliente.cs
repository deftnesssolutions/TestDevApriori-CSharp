using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GO.Providers;
using GO.Entities;
using GO.DAO;
using System.Data.SqlClient;

namespace ControleOrcamentoBAL
{
    public partial class frmCliente : ControleOrcamentoBAL.Plantilla
    {
        public static string nomeFormulario = "frmCliente";
        MaskedTextBox dynamicMaskedTextBox = new MaskedTextBox();
        string titulo = "Controle de Orçamento - Cadastro de Cliente";
        
        System.Globalization.CultureInfo cultureinfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        public frmCliente()
        {
            InitializeComponent();
            
        }

        private void frmClietne_Load(object sender, EventArgs e)
        {           
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            using (IConnection Conexion = new Connection())
            {
                IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                dgvCliente.Rows.Clear();
                //string texto = "este é um texto de exemplo";
                //texto = cultureinfo.TextInfo.ToTitleCase(texto);
                foreach (Cliente e in daoCli.All())
                {
                    int renglon = dgvCliente.Rows.Add();
                    dgvCliente.Rows[renglon].Cells["Id"].Value = e.Id.ToString();
                    dgvCliente.Rows[renglon].Cells["Nome"].Value = cultureinfo.TextInfo.ToTitleCase(e.Nome.ToString().ToLower().Trim());
                    dgvCliente.Rows[renglon].Cells["Telefone"].Value = cultureinfo.TextInfo.ToTitleCase(e.Telefone.ToString().ToLower().Trim());                    
                }
            }
        }

        //Cuadro de mensaje personalizado para utilizar en toda la aplicación
        public void mensagemInfoExibir(String titulo, String texto)
        {
            MessageBox.Show(titulo, texto, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DefaultObjetos()
        {
            btnSalvar.Visible = false;
            btnDelete.Visible = false;
            btnCancelar.Visible = false;
            btnAdd.Visible = true;
            //btnBuscar.Visible = true;

            LimparCampo();

            txtNome.Focus();
            LlenarGrid();
        }

        public void LimparCampo()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                mensagemInfoExibir("Insira o nome de Cliente !", titulo);
                txtNome.Focus();
                return;
            }

            if (txtTelefone.Text == "")
            {
                mensagemInfoExibir("Insira o telefone de Cliente !", titulo);
                txtNome.Focus();
                return;
            }

            using (IConnection Conexion = new Connection())
            {
                IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                Cliente cli = new Cliente();//Objeto tipo Modulos(tabela)
                string codnew = daoCli.CurremRegVal();
                /*
                if (int.Parse(codnew)+ 1 < 10)
                    cli.Id = 0 +int.Parse(codnew) + 1;
                else
                    cli.Id = int.Parse(codnew) + 1;
                */ 
                cli.Nome = txtNome.Text;
                cli.Telefone = txtTelefone.Text;
                // gravo los datos como registro en la tabla modulos
                daoCli.Insert(cli);
                DefaultObjetos();
            }
            LlenarGrid();
        }

        private void dgvCliente_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            //btnBuscar.Visible = false;
            btnSalvar.Visible = true;
            btnDelete.Visible = true;
            btnCancelar.Visible = true;
            string xcod = dgvCliente.CurrentRow.Cells["Id"].Value.ToString();
            using (IConnection conexion = new Connection())
            {
                IDAO<Cliente> daoCli = new DAOCliente(conexion);
                Cliente cli = daoCli.FindOrDefault(xcod);
                txtCodigo.Text = cli.Id.ToString();
                txtNome.Text = cli.Nome;
                txtTelefone.Text = cli.Telefone;               
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            using (IConnection Conexion = new Connection())
            {
                IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                Cliente cli = new Cliente();
                cli.Id = int.Parse(txtCodigo.Text);
                cli.Nome = txtNome.Text;
                cli.Telefone = txtTelefone.Text;
                
                // gravo los datos como registro en la tabla modulos
                daoCli.Update(cli);
            }

            DefaultObjetos();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
            using (IConnection Conexion = new Connection())
            {
                IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                Cliente cli = daoCli.FindOrDefault(txtCodigo.Text);
                daoCli.Delete(cli);
            }
            DefaultObjetos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DefaultObjetos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frm_Pesquisa.nomeFormulario = nomeFormulario;
            frm_Pesquisa fp = new frm_Pesquisa();
            fp.ShowDialog();
            if (fp.Codigo != null)
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                    Cliente cli = daoCli.FindOrDefault(fp.Codigo);
                    txtCodigo.Text = cli.Id.ToString();
                    txtNome.Text = cli.Nome;
                    txtTelefone.Text = cli.Telefone;
                    dgvCliente.Rows.Clear();
                    int renglon = dgvCliente.Rows.Add();
                    dgvCliente.Rows[renglon].Cells["Id"].Value = cli.Id.ToString();
                    dgvCliente.Rows[renglon].Cells["Nome"].Value = cultureinfo.TextInfo.ToTitleCase(cli.Nome.ToString().ToLower().Trim());
                    dgvCliente.Rows[renglon].Cells["Telefone"].Value = cultureinfo.TextInfo.ToTitleCase(cli.Telefone.ToString().ToLower().Trim());
              
                    btnAdd.Visible = false;
                    //btnBuscar.Visible = false;
                    btnSalvar.Visible = true;
                    btnDelete.Visible = true;
                    btnCancelar.Visible = true;
                }
            }
        }
    }
}
