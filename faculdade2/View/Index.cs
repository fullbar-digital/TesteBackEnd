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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }


        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroAluno cadastroAluno = new CadastroAluno();
            cadastroAluno.ShowDialog(this);

        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroDisciplina cadastroDisciplina = new CadastroDisciplina();
            cadastroDisciplina.ShowDialog(this);
        }

        private void cusosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCurso cadastroCurso = new CadastroCurso();
            cadastroCurso.ShowDialog(this);
        }
    }
}
