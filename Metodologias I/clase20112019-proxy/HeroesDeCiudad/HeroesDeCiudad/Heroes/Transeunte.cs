using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDeCiudad.Heroes
{
    class Transeunte:IInfartable
    {
        Random random;
        private double probabilidadConciencia;
        private double probabilidadRespirar;
        private double probabilidadRitmoCardiaco;

        public Transeunte(double probConciencia,double probRespirar,double probRitmoCardiaco,Random random)
        {
            this.probabilidadConciencia = probConciencia;
            this.probabilidadRespirar = probRespirar;
            this.probabilidadRitmoCardiaco = probRitmoCardiaco;
            this.random = random;
        }
        public bool estasConciente()
        {
            return random.NextDouble() > this.probabilidadConciencia; 
        }
        public bool estasRespirando()
        {
            return random.NextDouble() > this.probabilidadRespirar;
        }
        public bool tenesRitmoCardiaco()
        {
            return random.NextDouble() > this.probabilidadRitmoCardiaco;
		}
    }
}
