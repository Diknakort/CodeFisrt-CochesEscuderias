using CodeFisrt_CochesEscuderias.Models;

namespace CodeFisrt_CochesEscuderias.Services.Repositorio
{
    public interface ICocheRepositorio
    {
        List<Coche> DameTodos();
        Coche? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(Coche coche);
        void Modificar(int id, Coche coche);


    }
}
