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
    public partial class Plantilla : Form
    {

        #region Miembros del Forumulario

        private DataTable dtMenus;
        private System.Reflection.Assembly Ensamblado;
       // private AccesoDatos.Conexion Sistema;
        public static Int32 id_Grupo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.ComponentModel.IContainer components = null;

        private Int32 _id_grupo;
        private bool _insertar;
        private bool _deletar;
        private bool _atualizar;
        private bool _consultar;
        #endregion

        #region Propiedades del Formulario
        public bool Consultar
        {
            get { return _consultar; }
            set { _consultar = value; }
        }

        public bool Atualizar
        {
            get { return _atualizar; }
            set { _atualizar = value; }
        }

        public bool Deletar
        {
            get { return _deletar; }
            set { _deletar = value; }
        }

        public bool Insertar
        {
            get { return _insertar; }
            set { _insertar = value; }
        }

        public Int32 Id_grupo
        {
            get { return _id_grupo; }
            set { _id_grupo = value; }
        }
        #endregion

        #region Gestion de Menu
        /*
        private void CargarMenus(Int32 idGrupo)
        {
            AccesoDatos.MenusApp Menus = new AccesoDatos.MenusApp();
            dtMenus = new DataTable();
            dtMenus = Menus.MenusWindowsBS(idGrupo);
            foreach (DataRow MenuPadre in dtMenus.Select("id_menupadre=0", "posicaomenu ASC"))
            {
                ToolStripItem[] Menu = new ToolStripItem[1];
                Menu[0] = new ToolStripMenuItem();
                Menu[0].Name = MenuPadre["id_menu"].ToString();
                Menu[0].Text = MenuPadre["descricaomenu"].ToString().Trim();
                Menu[0].Tag = MenuPadre["urlmenu"].ToString().Trim();
                //Averigua si tiene hijo o no
                if (dtMenus.Select("id_menupadre=" + MenuPadre["id_menu"]).Length == 0)
                {
                    //si no tiene hijos lo agrego a la barra del menu principal
                    Menu[0].Click += new EventHandler(MenuItemClicked);
                    menuStrip1.Items.Add(Menu[0]);
                }
                else
                {
                    //si tiene hijos llamo a la funcion recursiva y agrego el item sin evento
                    menuStrip1.Items.Add(Menu[0]);
                    AgregarMenuHijo(Menu[0]);
                }
            }
        }

        private void AgregarMenuHijo(ToolStripItem MenuItemPadre)
        {
            ToolStripMenuItem MenuPadre = (ToolStripMenuItem)MenuItemPadre;
            //Obtengo el id del menu enviado para saber si tiene hijos o no
            string id = MenuPadre.Name;

            //averiguando si tiene hijos o no

            if (dtMenus.Select("id_menupadre=" + id).Length == 0)
            {
                //si no tiene hijos solo agrego el evento
                MenuPadre.Click += new EventHandler(MenuItemClicked);
            }
            else
            {
                //si aun tiene hijos
                foreach (DataRow Menu in dtMenus.Select("id_menupadre=" + id, "posicaomenu ASC"))
                {
                    ToolStripItem[] NuevoMenu = new ToolStripItem[1];
                    NuevoMenu[0] = new ToolStripMenuItem();
                    NuevoMenu[0].Name = Menu["id_menu"].ToString();
                    NuevoMenu[0].Text = Menu["descricaomenu"].ToString().Trim();
                    NuevoMenu[0].Tag = Menu["urlmenu"].ToString().Trim();
                    //Averigua si es un separador
                    if (Menu["descricaomenu"].ToString().Trim() == "-")
                    {
                        MenuPadre.DropDownItems.Add(NuevoMenu[0].Text);
                    }
                    else
                    {
                        //obtengo el ID del menu del foreach
                        //averiguando si tiene hijos o no
                        if (dtMenus.Select("id_menupadre=" + Menu["id_menu"]).Length == 0)
                        {
                            //si no tiene hijos lo agrego al menu padre
                            NuevoMenu[0].Click += new EventHandler(MenuItemClicked);
                            MenuPadre.DropDownItems.Add(NuevoMenu[0]);
                        }
                        else
                        {
                            //si tiene hojos llamo a la funcion recursiva y agrego el item sin evento
                            MenuPadre.DropDownItems.Add(NuevoMenu[0]);
                            AgregarMenuHijo(NuevoMenu[0]);
                        }
                    }
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            //if the sender is a toolStripMenuItem
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                string NombreFormulario = ((ToolStripItem)sender).Tag.ToString();
                if (NombreFormulario == "Sair")
                {
                    Application.Exit();
                }
                if (NombreFormulario == "Cascada")
                {
                    this.LayoutMdi(MdiLayout.Cascade);
                    return;
                }
                if (NombreFormulario == "Icono")
                {
                    this.LayoutMdi(MdiLayout.ArrangeIcons);
                    return;
                }
                if (NombreFormulario == "Horizontal")
                {
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    return;
                }
                if (NombreFormulario == "Vertical")
                {
                    this.LayoutMdi(MdiLayout.TileVertical);
                    return;
                }

                Object objFrm;
                //Type tipo = default(Type);
                Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
                if (tipo == null)
                {

                    MessageBox.Show("Formulario não encontrado", "Error de ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!this.FormularioEstaAbierto(NombreFormulario))
                    {
                        objFrm = Activator.CreateInstance(tipo);
                        Plantilla Formulario = (Plantilla)objFrm;
                        Formulario.Id_grupo = id_Grupo;
                        Formulario.MdiParent = MdiParent;
                        Formulario.Show();
                    }
                }

            }
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (this.MdiChildren.Length > 0)
            {
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i].Name == NombreDelFrm.Substring(NombreDelFrm.IndexOf("BS_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("BS_")))
                    {
                        MessageBox.Show("O formulario solicitado encontrase aberto");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
         */ 
        #endregion

        public Plantilla()
        {
            InitializeComponent();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Plantilla_Load(object sender, EventArgs e)
        {
            //menuStrip1.Items.Clear();
            //this.CargarMenus(frm_MDI_Principal.id_Grupo);
           // AccesoDatos.MenusApp permisos = new AccesoDatos.MenusApp();
            //permisos.ObtenerPermisos(Id_grupo, Name, ref lbl_Insertar, ref lbl_Atualizar, ref lbl_Consultar, ref lbl_Deletar);
 
        }
    }
}
