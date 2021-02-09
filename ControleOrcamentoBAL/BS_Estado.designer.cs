namespace Aplicativo.SistemaBase
{
    partial class BS_Estado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Insertar
            // 
            this.lbl_Insertar.Size = new System.Drawing.Size(316, 13);
            this.lbl_Insertar.Text = "WDF? hay catalogos con el mismo nombre y diferente ubicacion?";
            // 
            // lbl_Atualizar
            // 
            this.lbl_Atualizar.Size = new System.Drawing.Size(316, 13);
            this.lbl_Atualizar.Text = "WDF? hay catalogos con el mismo nombre y diferente ubicacion?";
            // 
            // lbl_Deletar
            // 
            this.lbl_Deletar.Size = new System.Drawing.Size(316, 13);
            this.lbl_Deletar.Text = "WDF? hay catalogos con el mismo nombre y diferente ubicacion?";
            // 
            // lbl_Consultar
            // 
            this.lbl_Consultar.Size = new System.Drawing.Size(316, 13);
            this.lbl_Consultar.Text = "WDF? hay catalogos con el mismo nombre y diferente ubicacion?";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Location = new System.Drawing.Point(35, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 48);
            this.panel1.TabIndex = 21;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::Aplicativo.Properties.Resources.esp_Ext1;
            this.btnCerrar.Location = new System.Drawing.Point(853, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(51, 30);
            this.btnCerrar.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnCerrar, "Fechar Janela");
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Aplicativo.Properties.Resources.add_item;
            this.btnAdd.Location = new System.Drawing.Point(752, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnAdd, "Guardar nuevo registro");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(96, 19);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(650, 20);
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(95, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Descricão:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(10, 19);
            this.txtCodigo.MaxLength = 2;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código:";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Aplicativo.Properties.Resources.delete1;
            this.btnDelete.Location = new System.Drawing.Point(854, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 30);
            this.btnDelete.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar registro selecionado");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Aplicativo.Properties.Resources.add_file;
            this.btnSalvar.Location = new System.Drawing.Point(804, 11);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(51, 30);
            this.btnSalvar.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnSalvar, "Salvar modificações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Aplicativo.Properties.Resources.can;
            this.btnCancelar.Location = new System.Drawing.Point(754, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(51, 30);
            this.btnCancelar.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnCancelar, "Limpar campos");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvDados);
            this.panel2.Location = new System.Drawing.Point(34, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 399);
            this.panel2.TabIndex = 22;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao});
            this.dgvDados.Location = new System.Drawing.Point(10, 7);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(892, 383);
            this.dgvDados.TabIndex = 7;
            this.dgvDados.Click += new System.EventHandler(this.dgvDados_Click);
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigo.FillWeight = 50.76143F;
            this.codigo.HeaderText = "CODIGO";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.HeaderText = "DESCRICAO";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 750;
            // 
            // BS_Estado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(986, 525);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "BS_Estado";
            this.Load += new System.EventHandler(this.BS_Estado_Load);
            this.Controls.SetChildIndex(this.lbl_Insertar, 0);
            this.Controls.SetChildIndex(this.lbl_Atualizar, 0);
            this.Controls.SetChildIndex(this.lbl_Deletar, 0);
            this.Controls.SetChildIndex(this.lbl_Consultar, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
