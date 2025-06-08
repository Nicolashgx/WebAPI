using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    public class AuditBase
    {
        [Key] //pk
        [Required] //significa que este campo es obligatorio
        public virtual Guid id { get; set; } //primary key de todas las tablas
        public virtual DateTime? CreatedDate { get; set; } // guardar todo registro nuevo con su date

        public virtual DateTime? ModifiedDate { get; set; } // guardar todo registro actualizado con su date
    }
}
