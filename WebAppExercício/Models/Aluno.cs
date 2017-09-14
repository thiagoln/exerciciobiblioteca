using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppExercício.Models
{
    public class Aluno
    {

        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Requisicao> Requisicoes { get; set; }

    }
}