namespace CodeFisrt_CochesEscuderias.Models
{
    public class Escuderia
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public int Dinero { get; set; }
        public virtual ICollection<Coche> Coches { get; set; }
    }
}
