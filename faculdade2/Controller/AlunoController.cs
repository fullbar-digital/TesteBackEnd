using faculdade2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faculdade2.Controller
{
    class AlunoController
    {
        Model1Container db = new Model1Container();

        public void cadastrarAluno(Aluno aluno)
        {
            try
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
                MessageBox.Show("Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível cadastrar");
            }
        }
    }
}
