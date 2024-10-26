using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Heroes;

namespace HeroesDeCiudad.Patrones
{
    class Adapter : IInfartable
    {
        Passerby passerby;
        public Adapter(Passerby passerby)
        {
            this.passerby = passerby;
        }
        public bool estasConciente()
        {
            return passerby.isConscious();
        }      
        public bool estasRespirando()
        {
            return passerby.isBreathing();
        }
        public bool tenesRitmoCardiaco()
        {
            return passerby.haveHeartRate();
        }
    }



}
