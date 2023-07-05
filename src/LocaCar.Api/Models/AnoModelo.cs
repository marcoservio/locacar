using System.ComponentModel.DataAnnotations.Schema;

namespace LocaCar.Api.Models
{
    public class AnoModelo
    {
        public virtual Ano Ano { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}
