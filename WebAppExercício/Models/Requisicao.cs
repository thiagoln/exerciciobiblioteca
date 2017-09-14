using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppExercício.Models
{
    public class Requisicao
    {
        public int RequisicaoId { get; set; }
        public int LivroId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataRequisicao { get; set; }
        public DateTime DataEntrega { get; set; }
        public Aluno Aluno { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public Livro Livro { get; set; }
    }
}