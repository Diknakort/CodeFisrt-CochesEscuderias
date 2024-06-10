using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFisrt_CochesEscuderias.Models
{

    [ModelMetadataType(typeof(MetaDataCoche))]
    public partial class Coche { }
    public class MetaDataCoche
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Potencia de motor")]
        public int Motor { get; set; }
        [DisplayName("Escuderia al que pertenece")]
        public int EscuderiaId { get; set; }
    }
}



