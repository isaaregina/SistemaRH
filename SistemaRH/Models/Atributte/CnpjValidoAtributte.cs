using System.ComponentModel.DataAnnotations;

namespace SistemaRH.Models.Atributte
{
    public class CnpjValidoAtributte : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && CpfCnpjLibrary.Cnpj.Validar(value.ToString());
        }
    }
}
