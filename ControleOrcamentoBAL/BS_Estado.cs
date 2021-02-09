using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AccesoDatos;
using AccesoDatos.SistemaBase.Entities;
using AccesoDatos.SistemaBase.Dao;

namespace Aplicativo.SistemaBase
{
    public partial class BS_Estado : Aplicativo.Plantilla
    {
        public BS_Estado()
        {
            InitializeComponent();
        }

        private void BS_Estado_Load(object sender, EventArgs e)
        {
            MenusApp menus = new MenusApp();
            menus.ObtenerPermisos(Id_grupo, Name, ref lbl_Insertar, ref lbl_Atualizar, ref lbl_Deletar, ref lbl_Consultar);
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            using (Iconnection Conexion = new Conexion())
            {
                IDao<Estado> dao = new DaoEstado(Conexion);
                dgvDados.Rows.Clear();
                foreach (Estado entity in dao.All())
                {
                    int renglon = dgvDados.Rows.Add();
                    dgvDados.Rows[renglon].Cells["codigo"].Value = entity.codigo.ToString();
                    dgvDados.Rows[renglon].Cells["descricao"].Value = entity.descricao.ToString();
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
            btnCerrar.Visible = true;
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtDescricao.Focus();
            LlenarGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbl_Insertar.Text != "SI")
            {
                mensagemInfoExibir("Permisão de Inserir Registro denegada. Operação Cancelada!", MdiParent.Text);

                return;
            }

            if (txtDescricao.Text == "")
            {
                mensagemInfoExibir("Insira a Descrição!", MdiParent.Text);
                txtDescricao.Focus();
                return;
            }

            using (Iconnection Conexion = new Conexion())
            {

                IDao<Estado> dao = new DaoEstado(Conexion);
                Estado entity = new Estado();//Objeto tipo Modulos(tabela)
                entity.codigo = txtCodigo.Text;
                entity.descricao = txtDescricao.Text;
                // gravo los datos como registro en la tabla modulos
                dao.Insert(entity);

            }
            DefaultObjetos();
        }

        private void dgvDados_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            btnAdd.Visible = false;
            btnCerrar.Visible = false;
            btnSalvar.Visible = true;
            btnDelete.Visible = true;
            btnCancelar.Visible = true;
            txtCodigo.Text = dgvDados.CurrentRow.Cells["codigo"].Value.ToString();
            txtDescricao.Text = dgvDados.CurrentRow.Cells["descricao"].Value.ToString().Trim();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lbl_Atualizar.Text != "SI")
            {
                mensagemInfoExibir("Permisão de Atualização denegada. Operação Cancelada!", MdiParent.Text);
                DefaultObjetos();
                return;
            }

            if (txtDescricao.Text == "")
            {
                mensagemInfoExibir("Insira a Descrição!", MdiParent.Text);
                txtDescricao.Focus();
                return;
            }

            using (Iconnection Conexion = new Conexion())
            {
                IDao<Estado> dao = new DaoEstado(Conexion);
                Estado entity = new Estado();//Objeto tipo Modulos(tabela)
                entity.codigo = txtCodigo.Text;
                entity.descricao = txtDescricao.Text;
                // gravo los datos como registro en la tabla modulos
                dao.Update(entity);
                txtCodigo.Text = "";
                txtDescricao.Text = "";
            }

            DefaultObjetos();
        }

        private void txtDescricao_KeyUp(object sender, KeyEventArgs e)
        {
            using (Iconnection Conexion = new Conexion())
            {
                IDao<Estado> dao = new DaoEstado(Conexion);
                dgvDados.Rows.Clear();
                foreach (Estado entity in dao.filtroPorDescricao(txtDescricao.Text))
                {
                    int renglon = dgvDados.Rows.Add();
                    dgvDados.Rows[renglon].Cells["codigo"].Value = entity.codigo.ToString();
                    dgvDados.Rows[renglon].Cells["descricao"].Value = entity.descricao.ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbl_Deletar.Text != "SI")
            {
                mensagemInfoExibir("Permisão de Eliminar Registro denegada. Operação Cancelada!", MdiParent.Text);
                DefaultObjetos();
                return;
            }
            using (Iconnection Conexion = new Conexion())
            {
                IDao<Estado> dao = new DaoEstado(Conexion);
                Estado entity = dao.FindOrDefault(txtCodigo.Text);
                dao.Delete(entity);
            }
            DefaultObjetos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DefaultObjetos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
