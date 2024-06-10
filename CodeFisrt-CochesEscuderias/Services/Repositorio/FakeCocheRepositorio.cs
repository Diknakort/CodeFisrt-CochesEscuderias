using CodeFisrt_CochesEscuderias.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeFisrt_CochesEscuderias.Services.Repositorio
{
    public class FakeCocheRepositorio : ICocheRepositorio
    {
        private List<Coche> listaCoches = new();

        public FakeCocheRepositorio()
        {
            Agregar(new Coche
            {
                Id = 1,
                Nombre = "F31",
                Motor= 333,
                EscuderiaId=1

            });
            Agregar(new Coche
            {
                Id = 2,
                Nombre = "AM12",
                Motor = 223,
                EscuderiaId = 2
            });
            Agregar(new Coche
            {
                Id = 3,
                Nombre = "BC14",
                Motor = 321,
                EscuderiaId = 3
            });
            Agregar(new Coche
            {
                Id = 4,
                Nombre = "Flecha01",
                Motor = 123,
                EscuderiaId = 1
            });
            Agregar(new Coche
            {
                Id = 5,
                Nombre = "Unamuno",
                Motor = 251,
                EscuderiaId = 3
            });
            Agregar(new Coche
            {
                Id = 6,
                Nombre = "Alonsillo33",
                Motor = 300,
                EscuderiaId = 2
            });
        }
        public List<Coche> DameTodos()
        {
            return listaCoches;
        }
        public Coche? DameUno(int Id)
        {
            return listaCoches.FirstOrDefault(g => g.Id == Id);
        }
        public bool Borrar(int Id)
        {
            Coche? aBorrar = DameUno(Id);
            if (aBorrar != null)
            {
                listaCoches.Remove(aBorrar);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Agregar(Coche coche)
        {
            if (DameUno(coche.Id) != null)
            {
                return false;
            }
            else
            {
                Agregar(coche);
                return true;
            }
        }
        public void Modificar(int Id, Coche coche)
        {
            Coche? aModificar = DameUno(Id);
            if (aModificar != null)
            {

                aModificar.Nombre = coche.Nombre;

            }
        }
    }
}
