using System.ComponentModel.DataAnnotations;

namespace SistemaRH.Models.Atributte
{
    public class CpfValidoAtributte : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && CpfCnpjLibrary.Cpf.Validar(value.ToString());
        }
    }
}
