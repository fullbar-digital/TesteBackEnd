
namespace faculdade2.View
{
    partial class CadastroCurso
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
            this.textNomeCurso = new System.Windows.Forms.TextBox();
            this.buttonCadastrarCurso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Curso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "nome do curso:";
            // 
            // textNomeCurso
            // 
            this.textNomeCurso.Location = new System.Drawing.Point(144, 132);
            this.textNomeCurso.Name = "textNomeCurso";
            this.textNomeCurso.Size = new System.Drawing.Size(121, 20);
            this.textNomeCurso.TabIndex = 3;
            // 
            // buttonCadastrarCurso
            // 
            this.buttonCadastrarCurso.Location = new System.Drawing.Point(81, 322);
            this.buttonCadastrarCurso.Name = "buttonCadastrarCurso";
            this.buttonCadastrarCurso.Size = new System.Drawing.Size(170, 23);
            this.buttonCadastrarCurso.TabIndex = 14;
            this.buttonCadastrarCurso.Text = "Cadastrar";
            this.buttonCadastrarCurso.UseVisualStyleBackColor = true;
            this.buttonCadastrarCurso.Click += new System.EventHandler(this.buttonCadastrarCurso_Click);
            // 
            // CadastroCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 370);
            this.Controls.Add(this.buttonCadastrarCurso);
            this.Controls.Add(this.textNomeCurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroCurso";
            this.Text = "CadastroCurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNomeCurso;
        private System.Windows.Forms.Button buttonCadastrarCurso;
    }
}