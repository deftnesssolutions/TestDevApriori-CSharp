using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GO.DAO;
using GO.Entities;
using GO.Providers;

namespace ControleOrcamentoBAL
{
    public partial class frm_Pesquisa : Form
    {
        public static string nomeFormulario = "";
        
        private string codigo;
        private string descricao;
        
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public frm_Pesquisa()
        {
            InitializeComponent();
        }

        private void frm_Pesquisa_Load(object sender, EventArgs e)
        {
            this.Location = new Point(80, 150);
            if (nomeFormulario == "frmCliente")
            {
                this.Text = "Pesquisa de Cliente";
                LlenarGridSarch();
            }

            if (nomeFormulario == "frmProduto")
            {
                this.Text = "Pesquisa de Produto";
                LlenarGridSarch();
            }

            if (nomeFormulario == "frmOrcamento")
            {
                this.Text = "Pesquisa de Orçamento";
                LlenarGridSarch();
            } 
        }

        
        public void LlenarGridSarch()
        {
            if (nomeFormulario == "frmCliente")
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                    AgregarColGrid("Id", "Nome");
                    foreach (Cliente cli in daoCli.All())
                    {
                        int renglon = dgvSearch.Rows.Add();
                        dgvSearch.Rows[renglon].Cells["Id"].Value = cli.Id.ToString();
                        dgvSearch.Rows[renglon].Cells["Nome"].Value = cli.Nome.ToString();
                    }
                }
            }

            if (nomeFormulario == "frmProduto")
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Produto> daoProd = new DAOProduto(Conexion);
                    AgregarColGrid("Id", "Nome");
                    foreach (Produto prod in daoProd.All())
                    {
                        int renglon = dgvSearch.Rows.Add();
                        dgvSearch.Rows[renglon].Cells["Id"].Value = prod.Id.ToString();
                        dgvSearch.Rows[renglon].Cells["Nome"].Value = prod.Nome.ToString();
                    }
                }
            }

            if (nomeFormulario == "frmOrcamento")
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                    AgregarColGrid("Id", "Data");
                    foreach (OrcCab oc in dao.All())
                    {
                       int renglon = dgvSearch.Rows.Add();
                        dgvSearch.Rows[renglon].Cells["Id"].Value = oc.Nro.ToString();
                        dgvSearch.Rows[renglon].Cells["Data"].Value = oc.Data.ToString();
                    }
                }
            }
        }

        public void AgregarColGrid(string nomeColGrid1, string nomeColGrid2)
        {
                dgvSearch.ColumnCount = 2;
                dgvSearch.Columns[0].Name = ""+nomeColGrid1+"";
                dgvSearch.Columns[1].Name = ""+nomeColGrid2+"";
                dgvSearch.Rows.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                mensagemInfoExibir("Informe o código para pesquisar!", "Pesquisa");
                txtCodigo.Focus();
                return;
            }
            if (nomeFormulario == "frmCliente")
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Cliente> daoCli = new DAOCliente(Conexion);
                    Cliente cli = daoCli.FindOrDefault(txtCodigo.Text);
                    if (cli != null)
                    {
                        dgvSearch.Rows.Clear();
                        int renglon = dgvSearch.Rows.Add();
                        dgvSearch.Rows[renglon].Cells["Id"].Value = cli.Id.ToString();
                        dgvSearch.Rows[renglon].Cells["Nome"].Value = cli.Nome.ToString();
                    }
                    else
                    {
                        mensagemInfoExibir("Codigo não existe!", "Pesquisa");
                        txtCodigo.Focus();
                    }
                }
            }

            if (nomeFormulario == "frmProduto")
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Produto> daoProd = new DAOProduto(Conexion);
                    Produto prod = daoProd.FindOrDefault(txtCodigo.Text);
                    if (prod != null)
                    {
                        dgvSearch.Rows.Clear();
                        int renglon = dgvSearch.Rows.Add();
                        dgvSearch.Rows[renglon].Cells["Id"].Value = prod.Id.ToString();
                        dgvSearch.Rows[renglon].Cells["Nome"].Value = prod.Nome.ToString();
                    }
                    else
                    {
                        mensagemInfoExibir("Codigo não existe!", "Pesquisa");
                        txtCodigo.Focus();
                    }
                }
            }

            if (nomeFormulario == "frmOrcamento")
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                    OrcCab oc = dao.FindOrDefault(txtCodigo.Text);
                    if (oc != null)
                    {
                        dgvSearch.Rows.Clear();
                        int renglon = dgvSearch.Rows.Add();
                        dgvSearch.Rows[renglon].Cells["Id"].Value = oc.Nro.ToString();
                        dgvSearch.Rows[renglon].Cells["Data"].Value = oc.Data.ToString();
                    }
                    else
                    {
                        mensagemInfoExibir("Codigo não existe!", "Pesquisa");
                        txtCodigo.Focus();
                    }
                }
            }
        }

        private void dgvSearch_Click(object sender, EventArgs e)
        {
                txtCodigo.Text = dgvSearch.CurrentRow.Cells["Id"].Value.ToString();
                Codigo = dgvSearch.CurrentRow.Cells["Id"].Value.ToString();
                //txtDescricao.Text = dgvSearch.CurrentRow.Cells["DESCRIÇÃO"].Value.ToString().Trim();
                //Descricao = dgvSearch.CurrentRow.Cells["DESCRIÇÃO"].Value.ToString().Trim();
                this.Close();
        }

        //Cuadro de mensaje personalizado para utilizar en toda la aplicación
        public void mensagemInfoExibir(String titulo, String texto)
        {
            MessageBox.Show(titulo, texto, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
