using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppExercício.Models
{
    public class Funcionario
    {

        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public List<Requisicao> Requisicoes { get; set; }
    }
}