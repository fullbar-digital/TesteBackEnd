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
    public partial class CadastroCurso : Form
    {
        public CadastroCurso()
        {
            InitializeComponent();
        }

        private void buttonCadastrarCurso_Click(object sender, EventArgs e)
        {
            CursoController controller = new CursoController();
            Curso objeto = new Curso();
            objeto.NomeCurso = textNomeCurso.Text;        

            controller.cadastrarCurso(objeto);
        }

        private void comboDisciplina1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
