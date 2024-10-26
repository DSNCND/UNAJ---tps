using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Patrones
{
    public abstract class FactoryMethodSectores
    {
        private const int sectorPastoSeco = 1;
        private const int sectorArbolesGrandes = 2;
        private const int sectorMuchoCalor = 3;
        private const int sectorVentoso = 4;
        private const int sectorAsustado = 5;
        private const int sectorLluvioso = 6;
        
        
        public static Sector crearSectorSimple()
        {
            return new Sector();
        }
        public static ISector decorarSector(int tipo, ISector sector,int param)
        {

            FactoryMethodSectores fabrica = null;
            switch (tipo)
            {
                	case sectorPastoSeco: fabrica = new FabricaSectorPastoSeco();
                    break;
                	case sectorArbolesGrandes: fabrica = new FabricaSectorArbolesGrandes();
                    break;
                    case sectorMuchoCalor: fabrica = new FabricaSectorMuchoCalor();
                    break;
                    case sectorVentoso: fabrica = new FabricaSectorVentoso();
                    break;
                    case sectorAsustado: fabrica = new FabricaSectorAsustado();
                    break;
                    case sectorLluvioso: fabrica = new FabricaSectorLluvioso();
                    break;
            }
            return fabrica.decorarSector(sector,param);
        }

        public abstract ISector decorarSector(ISector sector, int param);
        
    }

    public class FabricaSectorPastoSeco : FactoryMethodSectores
    {
        public override ISector decorarSector(ISector sector, int param)
        {
            return new PastoSeco(sector);
        }
    }
    public class FabricaSectorArbolesGrandes: FactoryMethodSectores
    {       
		public override ISector decorarSector(ISector sector, int param)
		{
			return new ArbolesGrandes(sector);
		} 
    }                   
    public class FabricaSectorMuchoCalor : FactoryMethodSectores
    {
		public override ISector decorarSector(ISector sector, int param)
		{
			return new DiaDeMuchoCalor(sector,param);
		}
    }    
    public class FabricaSectorVentoso : FactoryMethodSectores
    {
		public override ISector decorarSector(ISector sector, int param)
		{
			return new DiaVentoso(sector,param);
		}
    }
    public class FabricaSectorAsustado : FactoryMethodSectores
    {
		public override ISector decorarSector(ISector sector, int param)
		{
			return new GenteAsustada(sector,param);
		}
    }
    public class FabricaSectorLluvioso : FactoryMethodSectores
    {
		public override ISector decorarSector(ISector sector, int param)
		{
			return new DiaLluvioso(sector,param);
		}
    }
    
}
