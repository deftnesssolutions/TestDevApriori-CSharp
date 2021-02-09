using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//################################################
//Modulo Login Prevenda(Permite el acesso al menu principal del sistema)
//Autor Programador: Gustavo Ovelar
//Data de finalização: 25/01/2021
//################################################

namespace ControleOrcamentoBAL
{
    public partial class frmInicio : Form
    {       
        public bool IngresoCorrecto = false;
        DateTime hora_atual = DateTime.Now;
        public frmInicio()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkBD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBD.Checked)
            {
                lblBD.Visible = true;
                txtBD.Visible = true;
            }
            else 
            {
                lblBD.Visible = false;
                txtBD.Visible = false;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {

                frm_MDI_Principal fp = new frm_MDI_Principal();
                fp.Show();   
                this.Visible = false;
                    
            }
        }


        private void frmInicio_Load(object sender, EventArgs e)
        {
            
            if (hora_atual.Hour >= 12 && hora_atual.Hour<=18)
            {
                lblSaludo.Text = "¡Boa Tarde!";
            }
            if (hora_atual.Hour >= 18)
            {
                lblSaludo.Text = "¡Bom Noite!";
            }
            this.txtUsuario.Text = "ADMIN";
            this.txtSenha.Text = "ADMIN";
        }

        
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConectar.Focus();
            }
        }

        private bool ValidarIngreso()
        {
            if (String.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
            {
                //this.errorProvider1.SetError(this.txtUsuario, "Escreve o nome do Usuario");
                //this.txtUsuario.Focus();
                this.txtUsuario.Text = "ADMIN";
                return true;
            }
            else if (String.IsNullOrEmpty(this.txtSenha.Text.Trim()))
            {
                //this.errorProvider1.SetError(this.txtSenha, "Escreve a Senha");
                //this.txtSenha.Focus();
                this.txtSenha.Text = "ADMIN";
                return true;
            }
            else
                return true;
        }
    }
}
