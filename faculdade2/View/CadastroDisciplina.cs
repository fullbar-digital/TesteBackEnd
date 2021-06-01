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
    public partial class CadastroDisciplina : Form
    {
        public CadastroDisciplina()
        {
            InitializeComponent();
        }

        private void buttonCadastrarDisciplina_Click(object sender, EventArgs e)
        {
            DisciplinaController controller = new DisciplinaController();
            Disciplina objeto = new Disciplina();
            objeto.NomeDisciplina = textNomeDisciplina.Text;
            objeto.NotaMinima = double.Parse(textNotaMinima.Text);
            objeto.IdCurso = comboCurso.SelectedIndex;

            controller.cadastrarDisciplina(objeto);
        }

    }
}
