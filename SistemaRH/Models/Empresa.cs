using SistemaRH.Models.Atributte;
using System.ComponentModel.DataAnnotations;

namespace SistemaRH.Models
{
    public class Empresa
    {
        public int EmpresaID { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Necessário 14 caracteres.")]
        [CnpjValidoAtributte(ErrorMessage = "CNPJ inválido.")]
        public string Cnpj { get; set; }

        public List<Funcionario>? Funcionarios { get; set; }

        public List<Departamento>? Departamentos { get; set; }
    }
}
