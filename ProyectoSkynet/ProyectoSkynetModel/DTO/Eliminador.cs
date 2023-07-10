using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSkynetModel.DTO
{
    public class Eliminador
    {
        private string numSerie;
        private string tipo;
        private int prioridadBase;
        private int prioridad;
        private string objetivo;
        private Int32 anioDestino;

        public string NumSerie { get => numSerie; set => numSerie = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int PrioridadBase { get => prioridadBase; set => prioridadBase = value; }
        public int Prioridad { get => prioridad; set => prioridad = value; }
        public string Objetivo { get => objetivo; set => objetivo = value; }
        public int AnioDestino { get => anioDestino; set => anioDestino = value; }


        public void calcularPrioridad()
        {
            if (this.objetivo.ToLower() == "eliminador")
            {
                this.prioridad = this.prioridadBase;
            }
            else {
                this.prioridad = 999;
            }
            
        }

        public override string ToString()
        {
            //return NumSerie + " " + Tipo + " " + Objetivo;
            return NumSerie + "  " + Tipo + "  " + PrioridadBase + "  " + Prioridad + "  " + Objetivo + "  " + AnioDestino;
        }
    }
}
