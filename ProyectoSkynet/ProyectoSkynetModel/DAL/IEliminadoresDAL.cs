using ProyectoSkynetModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSkynetModel.DAL
{
    public interface IEliminadoresDAL
    {
        void AgregarEliminador(Eliminador eliminador);

        List<Eliminador> ObtenerEliminadores();

        List<Eliminador> FiltrarEliminadores(string tipo, Int32 anio);

        void EliminarTodos();
    }
}
