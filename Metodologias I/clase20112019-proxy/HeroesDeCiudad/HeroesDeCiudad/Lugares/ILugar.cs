using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Patrones;


namespace HeroesDeCiudad.Lugares
{
    public interface ILugar:IObservado
    {
        Calle Calle { get; set; }
        ISector[][] getSectores();
        void chispa(int caudalDeLluvia, int temperatura, int velocidadDeViento);
    }
}
