using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.CustomCode;

namespace RDSM.Util
{
    public class Macros : CustomCode
    {
        public void abrirFormCumbustiveis()
        {
            Forms.frm_Combustivel frm = new Forms.frm_Combustivel();
            frm.PSO = PSO;
            frm.BSO = BSO;
            frm.ShowDialog();
        }
    }
}
