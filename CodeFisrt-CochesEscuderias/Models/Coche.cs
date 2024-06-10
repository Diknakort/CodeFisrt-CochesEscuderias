namespace CodeFisrt_CochesEscuderias.Models
{
    public partial class Coche
    {
        public int Id { get; set; }
        public required string Nombre{ get; set; }
        public required int Motor { get; set; }

        public int EscuderiaId { get; set; }
    }
}
