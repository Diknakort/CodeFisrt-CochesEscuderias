using System.Linq.Expressions;

namespace CodeFisrt_CochesEscuderias.Services.Repositorio
{
    public interface IGenericRepositorio<T> where T : class
    {
        Task<List<T>> DameTodos();
        T? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(T element);
        void Modificar(int Id, T element);
        List<T> Filtra(Expression<Func<T, bool>> predicado);
    }
}
