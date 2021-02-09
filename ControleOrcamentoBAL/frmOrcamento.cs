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

namespace ControleOrcamentoBAL
{
    public partial class frmOrcamento : ControleOrcamentoBAL.Plantilla
    {
        public static string nomeFormulario = "frmOrcamento";
        MaskedTextBox dynamicMaskedTextBox = new MaskedTextBox();
        string titulo = "Controle de Orçamento - Cadastro de Orçamento";
        //Lista para Adicionar Produtos no Orçamento
        List<OrcDet> lstOD =  new List<OrcDet>();
        string codnew = "0"; //Nro de Orçamento
        bool edit = false;
        System.Globalization.CultureInfo cultureinfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        
        public frmOrcamento()
        {
            InitializeComponent();
            
        }

        // Clase para llenar Combobox(solusion contorno por problema de ambiente)
        public class ListaCombobox
        {
            public string Id { get; set; }
            public string Nome { get; set; }
        }
       
        private void frmOrcamento_Load(object sender, EventArgs e)
        {
            
            using (IConnection Conexion = new Connection())
            {
                //Para nuevo nro de Orçamento
                IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                codnew = dao.CurremRegVal();
                if (codnew == "")
                {
                    codnew = "0";
                }
            }
            using (IConnection Conexion = new Connection())
            {
                DefaultObjetos();
                //Preenche o combobox de Cliente
                IDAO<Cliente> daoC = new DAOCliente(Conexion);
                List<ListaCombobox> lc = new List<ListaCombobox>();
                ListaCombobox entity = null;
                lc.Add(new ListaCombobox());
                foreach (Cliente c in daoC.All())
                {
                    entity = new ListaCombobox();
                    entity.Id = c.Id.ToString();
                    entity.Nome = c.Nome;
                    lc.Add(entity);
                }

                cboCliente.ValueMember = "Id";
                cboCliente.DisplayMember = "Nome";
                cboCliente.DataSource = lc;

                //Preenche o combobox de Produto
                IDAO<Produto> daoP = new DAOProduto(Conexion);
                List<ListaCombobox> lp = new List<ListaCombobox>();
                lp.Add(new ListaCombobox());
                foreach (Produto p in daoP.All())
                {
                    entity = new ListaCombobox();
                    entity.Id = p.Id.ToString();
                    entity.Nome = p.Nome;
                    lp.Add(entity);
                }
                
                cboProduto.DisplayMember = "Nome";
                cboProduto.ValueMember = "Id";
                cboProduto.DataSource = lp;
            }
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DefaultObjetos();
        }

        private void LlenarGrid()
        {
            
                //string texto = "este é um texto de exemplo";
                //texto = cultureinfo.TextInfo.ToTitleCase(texto);
                foreach (OrcDet od in lstOD )
                {
                    int renglon = dgvOrcamento.Rows.Add();
                    dgvOrcamento.Rows[renglon].Cells["Id"].Value = od.Nro.ToString();
                    dgvOrcamento.Rows[renglon].Cells["IdProduto"].Value = od.IdProduto.ToString();                    
                    dgvOrcamento.Rows[renglon].Cells["PUnit"].Value = od.PUnit.ToString();
                    dgvOrcamento.Rows[renglon].Cells["Qtd"].Value = od.Qtd.ToString();
                    dgvOrcamento.Rows[renglon].Cells["Total"].Value = od.Total.ToString();
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
            btnUpdate.Visible = false;
            btnBuscar.Visible = true;
            btnDelOrc.Visible = false;
            dgvOrcamento.Rows.Clear();
            cboCliente.SelectedValue = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            LimparCampo();

            cboCliente.Focus();
        }

        public void LimparCampo()
        {
            cboProduto.SelectedValue = "";
            txtDescricao.Text = "";
            txtPUnit.Text = "";
            txtQtd.Text = "";
            txtTotal.Text = "";
            //edit = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue == null)
            {
                mensagemInfoExibir("Selecione um Cliente !", titulo);
                cboCliente.Focus();
                return;
            }

            if (cboProduto.SelectedValue == null)
            {
                mensagemInfoExibir("Selecione um Produto !", titulo);
                cboProduto.Focus();
                return;
            }

            if (txtQtd.Text == "")
            {
                mensagemInfoExibir("Informe a Quantidade !", titulo);
                cboProduto.Focus();
                return;
            }
            
            OrcDet od = new OrcDet();
            /*
            if (edit == false)
                od.Nro = int.Parse(codnew) + 1;
            else
                
                */
            od.Nro = int.Parse(txtCodigo.Text);
            od.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
            od.PUnit = decimal.Parse(txtPUnit.Text);
            od.Qtd = int.Parse(txtQtd.Text);
            od.Total = decimal.Parse(txtTotal.Text);
            lstOD.Add(od);
            int renglon = dgvOrcamento.Rows.Add();
            dgvOrcamento.Rows[renglon].Cells["Id"].Value = od.Nro.ToString();
            dgvOrcamento.Rows[renglon].Cells["IdProduto"].Value = od.IdProduto.ToString();
            dgvOrcamento.Rows[renglon].Cells["PUnit"].Value = od.PUnit.ToString();
            dgvOrcamento.Rows[renglon].Cells["Qtd"].Value = od.Qtd.ToString();
            dgvOrcamento.Rows[renglon].Cells["Total"].Value = od.Total.ToString();
            LimparCampo();
            btnSalvar.Visible = true;
        }

        public void Insert()
        {
            using (IConnection Conexion = new Connection())
            {
                //Salva datos en Orçamento Cabecera
                IDAO<OrcCab> doc = new DAOOrcCab(Conexion);
                OrcCab oc = new OrcCab();
                //oc.Nro = int.Parse(txtCodigo.Text);
                oc.IdCliente = int.Parse(cboCliente.SelectedValue.ToString());
                oc.Data = Convert.ToDateTime(txtData.Text);
                // gravo los datos como registro en la tabla modulos
                doc.Insert(oc);
            }

            //Salva datos em Orçamento Detalle

            foreach (OrcDet od in lstOD)
            {
                using (IConnection Conexion = new Connection())
                {
                    //Salva datos en Orçamento Cabecera
                    IDAO<OrcDet> dod = new DAOOrcDet(Conexion);
                    OrcDet d = new OrcDet();
                    //oc.Nro = int.Parse(txtCodigo.Text);
                    d.Nro = od.Nro;
                    d.IdProduto = od.IdProduto;
                    d.PUnit = od.PUnit;
                    d.Qtd = od.Qtd;
                    d.Total = od.Total;
                    // gravo los datos como registro en la tabla modulos
                    dod.Insert(d);
                }
            }
            DefaultObjetos();
            dgvOrcamento.Rows.Clear();
            cboCliente.SelectedValue = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            lstOD.Clear();
            
        }

        public void Edit()
        {
            //Salva datos em Orçamento Detalle
            foreach (OrcDet od in lstOD)
            {
                using (IConnection Conexion = new Connection())
                {
                    //Salva datos en Orçamento Cabecera
                    IDAO<OrcDet> dod = new DAOOrcDet(Conexion);
                    OrcDet d = new OrcDet();
                    //oc.Nro = int.Parse(txtCodigo.Text);
                    d.Nro = od.Nro;
                    d.IdProduto = od.IdProduto;
                    d.PUnit = od.PUnit;
                    d.Qtd = od.Qtd;
                    d.Total = od.Total;
                    // gravo los datos como registro en la tabla modulos
                    dod.Insert(d);
                }
            }
            DefaultObjetos();
            cboCliente.Enabled = true;

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (edit)
                Edit();
            else
                Insert();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {      
            
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                OrcDet od = new OrcDet();
                od.Nro = int.Parse(txtCodigo.Text);
                od.IdProduto = int.Parse(cboProduto.SelectedValue.ToString());
                od.PUnit = decimal.Parse(txtPUnit.Text);
                od.Qtd = int.Parse(txtQtd.Text);
                od.Total = decimal.Parse(txtTotal.Text);
                dao.Delete(od);
            }
            using (IConnection Conexion = new Connection())
            {
                dgvOrcamento.Rows.Clear();
                //Pesquisa Orçamento Detalhe
                IDAO<OrcDet> dod = new DAOOrcDet(Conexion);
                foreach (OrcDet od in dod.All())
                {
                    if (od.Nro == int.Parse(txtCodigo.Text))
                    {
                        int renglon = dgvOrcamento.Rows.Add();
                        dgvOrcamento.Rows[renglon].Cells["Id"].Value = od.Nro.ToString();
                        dgvOrcamento.Rows[renglon].Cells["IdProduto"].Value = od.IdProduto.ToString();
                        dgvOrcamento.Rows[renglon].Cells["PUnit"].Value = od.PUnit.ToString();
                        dgvOrcamento.Rows[renglon].Cells["Qtd"].Value = od.Qtd.ToString();
                        dgvOrcamento.Rows[renglon].Cells["Total"].Value = od.Total.ToString();

                    }
                }
            }       
            btnDelete.Visible = false;

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DefaultObjetos();
            dgvOrcamento.Rows.Clear();
            txtCodigo.Text = "";
            cboCliente.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frm_Pesquisa.nomeFormulario = nomeFormulario;
            frm_Pesquisa fp = new frm_Pesquisa();
            fp.ShowDialog();
            if (fp.Codigo != null)
            {
                edit = true;
                btnUpdate.Visible = true;
                btnCancelar.Visible = true;
                lstOD.Clear();
                cboCliente.Enabled = false;

                using (IConnection Conexion = new Connection())
                {
                    dgvOrcamento.Rows.Clear();
                    //Pesquisa Orçamento Cabeceira
                    IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                    OrcCab oc = dao.FindOrDefault(fp.Codigo);
                    if (oc != null)
                    {
                        txtCodigo.Text = oc.Nro.ToString();
                        cboCliente.SelectedValue = oc.IdCliente.ToString();
                        txtData.Text = oc.Data.ToString();
                    }
                    //Pesquisa Orçamento Detalhe
                    IDAO<OrcDet> dod = new DAOOrcDet(Conexion);                    
                    foreach (OrcDet od in dod.All())
                    {
                        if (oc.Nro == od.Nro)
                        {           
                            int renglon = dgvOrcamento.Rows.Add();
                            dgvOrcamento.Rows[renglon].Cells["Id"].Value = od.Nro.ToString();
                            dgvOrcamento.Rows[renglon].Cells["IdProduto"].Value = od.IdProduto.ToString();                           
                            dgvOrcamento.Rows[renglon].Cells["PUnit"].Value = od.PUnit.ToString();
                            dgvOrcamento.Rows[renglon].Cells["Qtd"].Value = od.Qtd.ToString();
                            dgvOrcamento.Rows[renglon].Cells["Total"].Value = od.Total.ToString();                           

                        }
                    }             
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    //btnBuscar.Visible = false;
                    btnSalvar.Visible = false;
                    btnDelete.Visible = false;
                    btnCancelar.Visible = true;
                    btnDelOrc.Visible = true;
                    
                }
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue != null)
            {
                if (edit == false)
                {
                    using (IConnection Conexion = new Connection())
                    {
                        //Para nuevo nro de Orçamento
                        IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                        codnew = dao.CurremRegVal();
                        if (codnew == "")
                            txtCodigo.Text = "1";
                        else
                        {
                            int newcod = int.Parse(codnew) + 1;
                            txtCodigo.Text = newcod.ToString();
                        }

                    }
                }
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Cliente> dao = new DAOCliente(Conexion);
                    Cliente entity = dao.FindOrDefault(cboCliente.SelectedValue);//Objeto tipo Modulos(tabela)
                    if (entity != null)
                    {
                        txtNome.Text = entity.Nome;
                        txtTelefone.Text = entity.Telefone;
                    }
                }
            }
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedValue != null)
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Produto> dao = new DAOProduto(Conexion);
                    Produto entity = dao.FindOrDefault(cboProduto.SelectedValue);//Objeto tipo Modulos(tabela)
                    if (entity != null)
                    {
                        txtDescricao.Text = entity.Nome;
                        txtPUnit.Text = entity.preço.ToString();
                    } 
                }
            }
        }

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {
            if (txtQtd.Text != "" && txtPUnit.Text !="")
            {
                decimal calc = int.Parse(txtQtd.Text) * decimal.Parse(txtPUnit.Text);
                txtTotal.Text = calc.ToString();
            }
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dgvOrcamento_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancelar.Visible = true;
            cboProduto.SelectedValue = dgvOrcamento.CurrentRow.Cells["IdProduto"].Value.ToString();
            txtQtd.Text = dgvOrcamento.CurrentRow.Cells["Qtd"].Value.ToString();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                OrcDet od = new OrcDet();
                od.Nro = int.Parse(txtCodigo.Text);
                od.IdProduto = int.Parse(cboProduto.SelectedValue.ToString());
                od.PUnit = decimal.Parse(txtPUnit.Text);
                od.Qtd = int.Parse(txtQtd.Text);
                od.Total = decimal.Parse(txtTotal.Text);
                // gravo los datos como registro en la tabla modulos
                dao.Update(od);
                LimparCampo();
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
                btnDelete.Visible = false;
            }

        }

        private void btnDelOrc_Click(object sender, EventArgs e)
        {
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                OrcCab oc = dao.FindOrDefault(txtCodigo.Text);
                if (oc != null)
                {
                    dao.Delete(oc);
                }
                
            }
            DefaultObjetos();
            cboCliente.Enabled = true;
        }       
        
    }
}
