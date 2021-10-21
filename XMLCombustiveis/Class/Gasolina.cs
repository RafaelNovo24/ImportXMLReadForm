using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCombustiveis
{
    class Gasolina
    {

        public string TipoGasolina { get; set; }
        public decimal PrecUnit { get; set; }
        public decimal VolumeTotal { get; set; }
        public decimal QuantidadeTotal { get; set; }
        public decimal VolumeDiario { get; set; }
        public decimal QuantidadeDiaria { get; set; }

        public Gasolina()
        {

        }

        public override string ToString()
        {
            if (PrecUnit.ToString() == "")
            {
                PrecUnit = 0;
            }
            if (VolumeTotal.ToString() == "")
            {
                VolumeTotal = 0;
            }
            if (QuantidadeTotal.ToString() == "")
            {
                QuantidadeTotal = 0;
            }

            return $"{TipoGasolina} |   {PrecUnit}€   | Volume Total: {VolumeTotal}L  |  Volume Diário {VolumeDiario}L  |  Valor Total:{QuantidadeTotal}€  |  Valor Diário: {QuantidadeDiaria}€ ";
        }

    }
}
