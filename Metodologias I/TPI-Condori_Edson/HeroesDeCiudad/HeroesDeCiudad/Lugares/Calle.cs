using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDeCiudad.Lugares
{
    public class Calle:IIluminable
    {
        int longitud { get; set; }
        int cantidadFarolas { get; set; }
        double caudalAguaXMinuto;

        public Calle()
        { }

        public Calle(int longitud, int cantidadFarolas, double caudal)
        {
            this.longitud = longitud;
            this.cantidadFarolas = cantidadFarolas;
            this.caudalAguaXMinuto = caudal;
        }

        public double CaudalAguaXMinuto{ get  {
          return this.caudalAguaXMinuto;
        } set {
          this.caudalAguaXMinuto = value;
        } }

        public void revisarYCambiarLamparasQuemadas()
        {
            Console.WriteLine("A implementar cambio de luces //calle");
        }
    }
}
