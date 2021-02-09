namespace ControleOrcamentoBAL
{
    partial class frmOrcamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelOrc = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvOrcamento = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtPUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamento)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelOrc
            // 
            this.btnDelOrc.Image = global::ControleOrcamentoBAL.Properties.Resources.excluir;
            this.btnDelOrc.Location = new System.Drawing.Point(686, 4);
            this.btnDelOrc.Name = "btnDelOrc";
            this.btnDelOrc.Size = new System.Drawing.Size(51, 30);
            this.btnDelOrc.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnDelOrc, "Deletar Orçamento");
            this.btnDelOrc.UseVisualStyleBackColor = true;
            this.btnDelOrc.Click += new System.EventHandler(this.btnDelOrc_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::ControleOrcamentoBAL.Properties.Resources._cancel;
            this.btnCancelar.Location = new System.Drawing.Point(743, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(51, 30);
            this.btnCancelar.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar Edição");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::ControleOrcamentoBAL.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(797, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 30);
            this.btnDelete.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar Item Orçamento");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::ControleOrcamentoBAL.Properties.Resources.add_file;
            this.btnSalvar.Location = new System.Drawing.Point(854, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(51, 30);
            this.btnSalvar.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnSalvar, "Salvar");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::ControleOrcamentoBAL.Properties.Resources.saveall_edit;
            this.btnUpdate.Location = new System.Drawing.Point(805, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 30);
            this.btnUpdate.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnUpdate, "Salvar Modificações");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ControleOrcamentoBAL.Properties.Resources.add_item;
            this.btnAdd.Location = new System.Drawing.Point(805, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnAdd, "Adicionar Registro");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::ControleOrcamentoBAL.Properties.Resources.options;
            this.btnBuscar.Location = new System.Drawing.Point(149, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(51, 30);
            this.btnBuscar.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnBuscar, "Pesquisar Funcionarios");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.dgvOrcamento);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.txtPUnit);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboProduto);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtQtd);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(34, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 403);
            this.panel2.TabIndex = 2;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(719, 9);
            this.txtTotal.MaxLength = 50;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(79, 20);
            this.txtTotal.TabIndex = 75;
            // 
            // dgvOrcamento
            // 
            this.dgvOrcamento.AllowUserToAddRows = false;
            this.dgvOrcamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrcamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrcamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdProduto,
            this.PUnit,
            this.Qtd,
            this.Total});
            this.dgvOrcamento.Location = new System.Drawing.Point(9, 37);
            this.dgvOrcamento.Name = "dgvOrcamento";
            this.dgvOrcamento.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrcamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrcamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrcamento.Size = new System.Drawing.Size(897, 320);
            this.dgvOrcamento.TabIndex = 17;
            this.dgvOrcamento.Click += new System.EventHandler(this.dgvOrcamento_Click);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.FillWeight = 38.28384F;
            this.Id.HeaderText = "Nro";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // IdProduto
            // 
            this.IdProduto.HeaderText = "IdProduto";
            this.IdProduto.Name = "IdProduto";
            this.IdProduto.ReadOnly = true;
            // 
            // PUnit
            // 
            this.PUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PUnit.FillWeight = 150.3818F;
            this.PUnit.HeaderText = "PUnit";
            this.PUnit.Name = "PUnit";
            this.PUnit.ReadOnly = true;
            // 
            // Qtd
            // 
            this.Qtd.HeaderText = "Qtd";
            this.Qtd.Name = "Qtd";
            this.Qtd.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(185, 10);
            this.txtDescricao.MaxLength = 80;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(272, 20);
            this.txtDescricao.TabIndex = 68;
            // 
            // txtPUnit
            // 
            this.txtPUnit.Location = new System.Drawing.Point(505, 11);
            this.txtPUnit.MaxLength = 50;
            this.txtPUnit.Name = "txtPUnit";
            this.txtPUnit.ReadOnly = true;
            this.txtPUnit.Size = new System.Drawing.Size(72, 20);
            this.txtPUnit.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(677, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 76;
            this.label6.Text = "Total:";
            // 
            // cboProduto
            // 
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(67, 10);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(112, 21);
            this.cboProduto.TabIndex = 1;
            this.cboProduto.SelectedIndexChanged += new System.EventHandler(this.cboProduto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(463, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 71;
            this.label3.Text = "P. Unt:";
            // 
            // txtQtd
            // 
            this.txtQtd.Location = new System.Drawing.Point(627, 10);
            this.txtQtd.MaxLength = 50;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(42, 20);
            this.txtQtd.TabIndex = 2;
            this.txtQtd.TextChanged += new System.EventHandler(this.txtQtd_TextChanged);
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(585, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 74;
            this.label5.Text = "Qtd:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(11, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "Produto:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtData);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboCliente);
            this.panel1.Controls.Add(this.txtTelefone);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(34, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 87);
            this.panel1.TabIndex = 1;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(244, 12);
            this.txtData.MaxLength = 50;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(119, 20);
            this.txtData.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(207, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Data:";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(65, 46);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(173, 21);
            this.cboCliente.TabIndex = 2;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(714, 46);
            this.txtTelefone.MaxLength = 50;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.ReadOnly = true;
            this.txtTelefone.Size = new System.Drawing.Size(119, 20);
            this.txtTelefone.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(652, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Telefone:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(244, 47);
            this.txtNome.MaxLength = 80;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(402, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cliente:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(65, 12);
            this.txtCodigo.MaxLength = 2;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nro:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnDelOrc);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnSalvar);
            this.panel3.Location = new System.Drawing.Point(34, 474);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(918, 39);
            this.panel3.TabIndex = 18;
            // 
            // frmOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(986, 525);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmOrcamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Orçamento(frmOrcamento)";
            this.Load += new System.EventHandler(this.frmOrcamento_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOrcamento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtPUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelOrc;

    }
}
