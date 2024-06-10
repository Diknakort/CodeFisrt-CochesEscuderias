using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CodeFisrt_CochesEscuderias.Models;

namespace CodeFisrt_CochesEscuderias.Services.Repositorio
{
    public class EFGenericRepositorio<T> : IGenericRepositorio<T> where T : class

    {
        private readonly CircuitosContexto _context = new();
        public async Task<List<T>> DameTodos()
        {
            return await _context.Set<T>().ToListAsync();

        }


        public async Task<T?> DameUno(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<bool> Borrar(int Id)
        {
            var elemento = await DameUno(Id);
            _context.Set<T>().Remove(elemento);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Agregar(T element)
        {
            _context.Set<T>().Add(element);
            _context.SaveChanges();
            return true;
        }

        public async Task Modificar(int Id, T element)
        {
            _context.Entry(element).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<List<T>> Filtra(Expression<Func<T, bool>> predicado)
        {
            return await _context.Set<T>().Where<T>(predicado).ToListAsync();
        }
    }
}
// NO ASYNC
//{
//    private readonly CircuitosContexto _context = new();
//    public List<T> DameTodos()
//    {
//        return _context.Set<T>().AsNoTracking().ToList();
//    }

//    public T? DameUno(int Id)
//    {
//        return _context.Set<T>().Find(Id);
//    }

//    public bool Borrar(int Id)
//    {
//        var elemento = DameUno(Id);
//        _context.Set<T>().Remove(elemento);
//        _context.SaveChanges();
//        return true;
//    }

//    public bool Agregar(T element)
//    {
//        _context.Set<T>().Add(element);
//        _context.SaveChanges();
//        return true;
//    }

//    public void Modificar(int Id, T element)
//    {
//        _context.Entry(element).State = EntityState.Modified;
//        _context.SaveChanges();
//    }

//    public List<T> Filtra(Expression<Func<T, bool>> predicado)
//    {
//        return _context.Set<T>().Where<T>(predicado).ToList();
//    }
//}

