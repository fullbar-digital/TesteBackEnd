using faculdade2.Controller;
using faculdade2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faculdade2.View
{
    public partial class CadastroAluno : Form
    {
        public CadastroAluno()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textRA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textFoto = new System.Windows.Forms.TextBox();
            this.comboPeriodo = new System.Windows.Forms.ComboBox();
            this.comboCurso = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aluno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "nome:";
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(103, 103);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(121, 20);
            this.textNome.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "RA:";
            // 
            // textRA
            // 
            this.textRA.Location = new System.Drawing.Point(103, 149);
            this.textRA.Name = "textRA";
            this.textRA.Size = new System.Drawing.Size(121, 20);
            this.textRA.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Período:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Curso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Foto:";
            // 
            // textFoto
            // 
            this.textFoto.Location = new System.Drawing.Point(103, 320);
            this.textFoto.Name = "textFoto";
            this.textFoto.Size = new System.Drawing.Size(121, 20);
            this.textFoto.TabIndex = 9;
            // 
            // comboPeriodo
            // 
            this.comboPeriodo.FormattingEnabled = true;
            this.comboPeriodo.Location = new System.Drawing.Point(103, 200);
            this.comboPeriodo.Name = "comboPeriodo";
            this.comboPeriodo.Size = new System.Drawing.Size(121, 21);
            this.comboPeriodo.TabIndex = 10;
            // 
            // comboCurso
            // 
            this.comboCurso.FormattingEnabled = true;
            this.comboCurso.Location = new System.Drawing.Point(103, 239);
            this.comboCurso.Name = "comboCurso";
            this.comboCurso.Size = new System.Drawing.Size(121, 21);
            this.comboCurso.TabIndex = 11;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(100, 280);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(60, 13);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Reprovado";
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.Location = new System.Drawing.Point(69, 355);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(170, 23);
            this.buttonCadastrar.TabIndex = 13;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // CadastroAluno
            // 
            this.ClientSize = new System.Drawing.Size(319, 390);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboCurso);
            this.Controls.Add(this.comboPeriodo);
            this.Controls.Add(this.textFoto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textRA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroAluno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            AlunoController controller = new AlunoController();
            Aluno objeto = new Aluno();
            objeto.Nome = textNome.Text;
            objeto.Período = comboPeriodo.SelectedItem.ToString();
            objeto.Curso = comboCurso.SelectedItem.ToString();
            objeto.Status = labelStatus.Text;
            objeto.RA = textRA.Text;
            objeto.Foto = textFoto.Text;
            objeto.IdCurso = comboCurso.SelectedIndex;
            controller.cadastrarAluno(objeto);
        }
    }
}
