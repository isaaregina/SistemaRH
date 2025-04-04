using System.ComponentModel.DataAnnotations;

namespace SistemaRH.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int FuncionarioID { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
