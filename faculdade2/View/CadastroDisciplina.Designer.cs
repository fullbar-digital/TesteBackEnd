
namespace faculdade2.View
{
    partial class CadastroDisciplina
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textNomeDisciplina = new System.Windows.Forms.TextBox();
            this.textNotaMinima = new System.Windows.Forms.TextBox();
            this.buttonCadastrarDisciplina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disciplina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "nome disciplina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "nota mínima:";
            // 
            // textNomeDisciplina
            // 
            this.textNomeDisciplina.Location = new System.Drawing.Point(165, 120);
            this.textNomeDisciplina.Name = "textNomeDisciplina";
            this.textNomeDisciplina.Size = new System.Drawing.Size(121, 20);
            this.textNomeDisciplina.TabIndex = 5;
            // 
            // textNotaMinima
            // 
            this.textNotaMinima.Location = new System.Drawing.Point(165, 175);
            this.textNotaMinima.Name = "textNotaMinima";
            this.textNotaMinima.Size = new System.Drawing.Size(121, 20);
            this.textNotaMinima.TabIndex = 6;
            // 
            // buttonCadastrarDisciplina
            // 
            this.buttonCadastrarDisciplina.Location = new System.Drawing.Point(86, 274);
            this.buttonCadastrarDisciplina.Name = "buttonCadastrarDisciplina";
            this.buttonCadastrarDisciplina.Size = new System.Drawing.Size(170, 23);
            this.buttonCadastrarDisciplina.TabIndex = 14;
            this.buttonCadastrarDisciplina.Text = "Cadastrar";
            this.buttonCadastrarDisciplina.UseVisualStyleBackColor = true;
            // 
            // CadastroDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 348);
            this.Controls.Add(this.buttonCadastrarDisciplina);
            this.Controls.Add(this.textNotaMinima);
            this.Controls.Add(this.textNomeDisciplina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroDisciplina";
            this.Text = "CadastrarDisciplina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNomeDisciplina;
        private System.Windows.Forms.TextBox textNotaMinima;
        private System.Windows.Forms.Button buttonCadastrarDisciplina;
    }
}