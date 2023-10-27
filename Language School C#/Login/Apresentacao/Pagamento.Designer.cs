namespace Login.Apresentacao
{
    partial class Pagamento
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
            System.Windows.Forms.Button btnPesquisarIdColaborador;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagamento));
            this.lbl_pesquisa = new System.Windows.Forms.Label();
            this.txtbox_pesquisa = new System.Windows.Forms.TextBox();
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.dtgHolerite = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            btnPesquisarIdColaborador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHolerite)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_pesquisa
            // 
            this.lbl_pesquisa.AutoSize = true;
            this.lbl_pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pesquisa.Location = new System.Drawing.Point(75, 28);
            this.lbl_pesquisa.Name = "lbl_pesquisa";
            this.lbl_pesquisa.Size = new System.Drawing.Size(93, 16);
            this.lbl_pesquisa.TabIndex = 0;
            this.lbl_pesquisa.Text = "ID Funcionario";
            // 
            // txtbox_pesquisa
            // 
            this.txtbox_pesquisa.Location = new System.Drawing.Point(183, 22);
            this.txtbox_pesquisa.Name = "txtbox_pesquisa";
            this.txtbox_pesquisa.Size = new System.Drawing.Size(190, 26);
            this.txtbox_pesquisa.TabIndex = 2;
            // 
            // btn_sair
            // 
            this.btn_sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sair.Location = new System.Drawing.Point(687, 402);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(75, 36);
            this.btn_sair.TabIndex = 23;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir.Location = new System.Drawing.Point(27, 402);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(75, 36);
            this.btn_imprimir.TabIndex = 23;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // dtgHolerite
            // 
            this.dtgHolerite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHolerite.Location = new System.Drawing.Point(122, 122);
            this.dtgHolerite.Name = "dtgHolerite";
            this.dtgHolerite.Size = new System.Drawing.Size(545, 263);
            this.dtgHolerite.TabIndex = 24;
            // 
            // btnPesquisarIdColaborador
            // 
            btnPesquisarIdColaborador.BackColor = System.Drawing.SystemColors.ActiveCaption;
            btnPesquisarIdColaborador.CausesValidation = false;
            btnPesquisarIdColaborador.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPesquisarIdColaborador.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarIdColaborador.Image")));
            btnPesquisarIdColaborador.Location = new System.Drawing.Point(534, 22);
            btnPesquisarIdColaborador.Margin = new System.Windows.Forms.Padding(0);
            btnPesquisarIdColaborador.Name = "btnPesquisarIdColaborador";
            btnPesquisarIdColaborador.Size = new System.Drawing.Size(106, 30);
            btnPesquisarIdColaborador.TabIndex = 25;
            btnPesquisarIdColaborador.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(btnPesquisarIdColaborador);
            this.groupBox1.Controls.Add(this.txtbox_pesquisa);
            this.groupBox1.Controls.Add(this.lbl_pesquisa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 62);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar";
            // 
            // Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgHolerite);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_sair);
            this.Name = "Pagamento";
            this.Text = "Folha de Pagamento";
            this.Load += new System.EventHandler(this.Pagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHolerite)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_pesquisa;
        private System.Windows.Forms.TextBox txtbox_pesquisa;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.DataGridView dtgHolerite;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}