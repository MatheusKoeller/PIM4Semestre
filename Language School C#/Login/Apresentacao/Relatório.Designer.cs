namespace Login.Apresentacao
{
    partial class Relatório
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
            this.lbl_pesquisa = new System.Windows.Forms.Label();
            this.txtbx_pesquisa = new System.Windows.Forms.TextBox();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_pesquisa
            // 
            this.lbl_pesquisa.AutoSize = true;
            this.lbl_pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pesquisa.Location = new System.Drawing.Point(12, 9);
            this.lbl_pesquisa.Name = "lbl_pesquisa";
            this.lbl_pesquisa.Size = new System.Drawing.Size(91, 16);
            this.lbl_pesquisa.TabIndex = 0;
            this.lbl_pesquisa.Text = "Nome ou CPF";
            // 
            // txtbx_pesquisa
            // 
            this.txtbx_pesquisa.Location = new System.Drawing.Point(15, 28);
            this.txtbx_pesquisa.Name = "txtbx_pesquisa";
            this.txtbx_pesquisa.Size = new System.Drawing.Size(182, 20);
            this.txtbx_pesquisa.TabIndex = 1;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Location = new System.Drawing.Point(15, 231);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(78, 30);
            this.btn_imprimir.TabIndex = 2;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(404, 231);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(78, 30);
            this.btn_sair.TabIndex = 2;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(494, 273);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.txtbx_pesquisa);
            this.Controls.Add(this.lbl_pesquisa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Relatórios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pesquisa;
        private System.Windows.Forms.TextBox txtbx_pesquisa;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_sair;
    }
}