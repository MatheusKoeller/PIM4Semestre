namespace Login.Apresentacao
{
    partial class Ponto
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
            this.lbl_pesquisar = new System.Windows.Forms.Label();
            this.chbox_rg = new System.Windows.Forms.CheckBox();
            this.chbox_cpf = new System.Windows.Forms.CheckBox();
            this.chbox_nome = new System.Windows.Forms.CheckBox();
            this.txtbx_pesquisa = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_justificativa = new System.Windows.Forms.Label();
            this.richtxt = new System.Windows.Forms.RichTextBox();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.btn_relatorio = new System.Windows.Forms.Button();
            this.brn_excluir = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_pesquisar
            // 
            this.lbl_pesquisar.AutoSize = true;
            this.lbl_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pesquisar.Location = new System.Drawing.Point(9, 9);
            this.lbl_pesquisar.Name = "lbl_pesquisar";
            this.lbl_pesquisar.Size = new System.Drawing.Size(94, 16);
            this.lbl_pesquisar.TabIndex = 0;
            this.lbl_pesquisar.Text = "Pesquisar por:";
            // 
            // chbox_rg
            // 
            this.chbox_rg.AutoSize = true;
            this.chbox_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbox_rg.Location = new System.Drawing.Point(133, 28);
            this.chbox_rg.Name = "chbox_rg";
            this.chbox_rg.Size = new System.Drawing.Size(44, 19);
            this.chbox_rg.TabIndex = 2;
            this.chbox_rg.Text = "RG";
            this.chbox_rg.UseVisualStyleBackColor = true;
            // 
            // chbox_cpf
            // 
            this.chbox_cpf.AutoSize = true;
            this.chbox_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbox_cpf.Location = new System.Drawing.Point(78, 28);
            this.chbox_cpf.Name = "chbox_cpf";
            this.chbox_cpf.Size = new System.Drawing.Size(49, 19);
            this.chbox_cpf.TabIndex = 3;
            this.chbox_cpf.Text = "CPF";
            this.chbox_cpf.UseVisualStyleBackColor = true;
            // 
            // chbox_nome
            // 
            this.chbox_nome.AutoSize = true;
            this.chbox_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbox_nome.Location = new System.Drawing.Point(12, 27);
            this.chbox_nome.Name = "chbox_nome";
            this.chbox_nome.Size = new System.Drawing.Size(60, 19);
            this.chbox_nome.TabIndex = 4;
            this.chbox_nome.Text = "Nome";
            this.chbox_nome.UseVisualStyleBackColor = true;
            // 
            // txtbx_pesquisa
            // 
            this.txtbx_pesquisa.Location = new System.Drawing.Point(12, 53);
            this.txtbx_pesquisa.Name = "txtbx_pesquisa";
            this.txtbx_pesquisa.Size = new System.Drawing.Size(165, 20);
            this.txtbx_pesquisa.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 263);
            this.dataGridView1.TabIndex = 6;
            // 
            // lbl_justificativa
            // 
            this.lbl_justificativa.AutoSize = true;
            this.lbl_justificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_justificativa.Location = new System.Drawing.Point(618, 28);
            this.lbl_justificativa.Name = "lbl_justificativa";
            this.lbl_justificativa.Size = new System.Drawing.Size(153, 16);
            this.lbl_justificativa.TabIndex = 7;
            this.lbl_justificativa.Text = "Justificativa de ausência";
            // 
            // richtxt
            // 
            this.richtxt.Location = new System.Drawing.Point(600, 53);
            this.richtxt.Name = "richtxt";
            this.richtxt.Size = new System.Drawing.Size(188, 310);
            this.richtxt.TabIndex = 8;
            this.richtxt.Text = "";
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(611, 369);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(82, 32);
            this.btn_editar.TabIndex = 9;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(699, 369);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(82, 32);
            this.btn_salvar.TabIndex = 9;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.Location = new System.Drawing.Point(12, 406);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(95, 32);
            this.btn_alterar.TabIndex = 10;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = true;
            // 
            // btn_relatorio
            // 
            this.btn_relatorio.Location = new System.Drawing.Point(113, 406);
            this.btn_relatorio.Name = "btn_relatorio";
            this.btn_relatorio.Size = new System.Drawing.Size(95, 32);
            this.btn_relatorio.TabIndex = 10;
            this.btn_relatorio.Text = "Gerar Relatório";
            this.btn_relatorio.UseVisualStyleBackColor = true;
            // 
            // brn_excluir
            // 
            this.brn_excluir.Location = new System.Drawing.Point(214, 406);
            this.brn_excluir.Name = "brn_excluir";
            this.brn_excluir.Size = new System.Drawing.Size(95, 32);
            this.brn_excluir.TabIndex = 10;
            this.brn_excluir.Text = "Excluir";
            this.brn_excluir.UseVisualStyleBackColor = true;
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(315, 406);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(95, 32);
            this.btn_sair.TabIndex = 10;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // Ponto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.brn_excluir);
            this.Controls.Add(this.btn_relatorio);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.richtxt);
            this.Controls.Add(this.lbl_justificativa);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtbx_pesquisa);
            this.Controls.Add(this.chbox_rg);
            this.Controls.Add(this.chbox_cpf);
            this.Controls.Add(this.chbox_nome);
            this.Controls.Add(this.lbl_pesquisar);
            this.Name = "Ponto";
            this.Text = "Ponto_eletronico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pesquisar;
        private System.Windows.Forms.CheckBox chbox_rg;
        private System.Windows.Forms.CheckBox chbox_cpf;
        private System.Windows.Forms.CheckBox chbox_nome;
        private System.Windows.Forms.TextBox txtbx_pesquisa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_justificativa;
        private System.Windows.Forms.RichTextBox richtxt;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.Button btn_relatorio;
        private System.Windows.Forms.Button brn_excluir;
        private System.Windows.Forms.Button btn_sair;
    }
}