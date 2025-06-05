using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] //identificar mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un Maximo de {1} caracteres") ] // limitar el numero de caracteres
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio
        public string Name { get; set; }
    }
}
