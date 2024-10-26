using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDeCiudad.Lugares
{
    public interface ISector
    {
        double GetPorcentajeDeAfectacion();
        void SetPorcentajeDeAfectacion(double porcentaje);
        bool EstaApagado();
        void mojar(double agua);

    }
}
