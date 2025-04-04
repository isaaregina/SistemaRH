using SistemaRH.Models.Atributte;
using System.ComponentModel.DataAnnotations;

namespace SistemaRH.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [CpfValidoAtributte(ErrorMessage = "CPF inválido.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Necessário 11 caracteres.")]
        public string Cpf { get; set; }

        public int DepartamentoID { get; set; }
        public Departamento? Departamento { get; set; }

        public int EmpresaID { get; set; }
        public Empresa? Empresa { get; set; }

        public List<Tarefa>? Tarefa { get; set; }
    }
}
