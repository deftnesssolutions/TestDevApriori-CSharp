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
    public partial class frmProduto : ControleOrcamentoBAL.Plantilla
    {
        public static string nomeFormulario = "frmProduto";
        MaskedTextBox dynamicMaskedTextBox = new MaskedTextBox();
        string titulo = "Controle de Orçamento - Cadastro de Produto";
        
        System.Globalization.CultureInfo cultureinfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        public frmProduto()
        {
            InitializeComponent();
            
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {           
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            using (IConnection Conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(Conexion);
                dgvProduto.Rows.Clear();
                //string texto = "este é um texto de exemplo";
                //texto = cultureinfo.TextInfo.ToTitleCase(texto);
                foreach (Produto p in dao.All())
                {
                    int renglon = dgvProduto.Rows.Add();
                    dgvProduto.Rows[renglon].Cells["Id"].Value = p.Id.ToString();
                    dgvProduto.Rows[renglon].Cells["Nome"].Value = cultureinfo.TextInfo.ToTitleCase(p.Nome.ToString().ToLower().Trim());
                    dgvProduto.Rows[renglon].Cells["Preco"].Value = cultureinfo.TextInfo.ToTitleCase(p.preço.ToString().ToLower().Trim());                    
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
            txtPreco.Text = "";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                mensagemInfoExibir("Insira o nome de Produto !", titulo);
                txtNome.Focus();
                return;
            }

            if (txtPreco.Text == "")
            {
                mensagemInfoExibir("Informe o preço de Produto !", titulo);
                txtNome.Focus();
                return;
            }

            using (IConnection Conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(Conexion);
                Produto prod = new Produto();//Objeto tipo Modulos(tabela)
                string codnew = dao.CurremRegVal();
                /*
                if (int.Parse(codnew)+ 1 < 10)
                    cli.Id = 0 +int.Parse(codnew) + 1;
                else
                    cli.Id = int.Parse(codnew) + 1;
                */ 
                prod.Nome = txtNome.Text;
                prod.preço = decimal.Parse(txtPreco.Text);
                // gravo los datos como registro en la tabla modulos
                dao.Insert(prod);
                DefaultObjetos();
            }
            LlenarGrid();
        }

        private void dgvProduto_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            //btnBuscar.Visible = false;
            btnSalvar.Visible = true;
            btnDelete.Visible = true;
            btnCancelar.Visible = true;
            string xcod = dgvProduto.CurrentRow.Cells["Id"].Value.ToString();
            using (IConnection conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(conexion);
                Produto prod = dao.FindOrDefault(xcod);
                txtCodigo.Text = prod.Id.ToString();
                txtNome.Text = prod.Nome;
                txtPreco.Text = prod.preço.ToString();               
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            using (IConnection Conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(Conexion);
                Produto prod = new Produto();
                prod.Id = int.Parse(txtCodigo.Text);
                prod.Nome = txtNome.Text;
                prod.preço = decimal.Parse(txtPreco.Text);
                
                // gravo los datos como registro en la tabla modulos
                dao.Update(prod);
            }

            DefaultObjetos();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
            using (IConnection Conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(Conexion);
                Produto prod = dao.FindOrDefault(txtCodigo.Text);
                dao.Delete(prod);
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
                    IDAO<Produto> dao = new DAOProduto(Conexion);
                    Produto prod = dao.FindOrDefault(fp.Codigo);
                    txtCodigo.Text = prod.Id.ToString();
                    txtNome.Text = prod.Nome;
                    txtPreco.Text = prod.preço.ToString();
                    dgvProduto.Rows.Clear();
                    int renglon = dgvProduto.Rows.Add();
                    dgvProduto.Rows[renglon].Cells["Id"].Value = prod.Id.ToString();
                    dgvProduto.Rows[renglon].Cells["Nome"].Value = cultureinfo.TextInfo.ToTitleCase(prod.Nome.ToString().ToLower().Trim());
                    dgvProduto.Rows[renglon].Cells["Preco"].Value = cultureinfo.TextInfo.ToTitleCase(prod.preço.ToString().ToLower().Trim());
              
                    btnAdd.Visible = false;
                    //btnBuscar.Visible = false;
                    btnSalvar.Visible = true;
                    btnDelete.Visible = true;
                    btnCancelar.Visible = true;
                }
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }
    }
}
