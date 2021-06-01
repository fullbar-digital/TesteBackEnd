using faculdade2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faculdade2.Controller
{
    class DisciplinaController
    {
        Model1Container db = new Model1Container();

        public void cadastrarDisciplina(Disciplina disciplina)
        {
            try
            {
                db.Disciplina.Add(disciplina);
                db.SaveChanges();
                MessageBox.Show("Cadastrado com sucesso");
            }catch(Exception e)
            {
                MessageBox.Show("Não foi possível cadastrar");
            }
        }
    }
}
