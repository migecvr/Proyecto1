using ProyectoSkynetModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSkynetModel.DAL
{
    public class EliminadoresDALObjetos : IEliminadoresDAL
    {
        private static List<Eliminador> eliminadores = new List<Eliminador>();
        public void AgregarEliminador(Eliminador eliminador)
        {
            eliminadores.Add(eliminador);
        }

        public void EliminarTodos()
        {
            eliminadores.Clear();
        }

        public List<Eliminador> FiltrarEliminadores(string tipo, int anio)
        {
            return eliminadores.FindAll(e => e.Tipo.ToLower() == tipo.ToLower() && e.AnioDestino == anio);
        }

        public List<Eliminador> ObtenerEliminadores()
        {
            return eliminadores;
        }
    }
}
