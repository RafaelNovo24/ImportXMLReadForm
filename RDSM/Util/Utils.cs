using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDSM.Util
{
    class Utils
    {

        public static void init_txtf4(StdPlatBS100.StdBSInterfPub PSO, PriTextBoxF4100.PriTextBoxF4 txtf4, PriTextBoxF4NET100.PriTextBoxF4.OpenListF4EventHandler func_open_list)
        {
            try
            {
                System.Windows.Forms.Control[] controls = txtf4.Controls.Find("_txtF4Net", false);

                if (controls[0] is PriTextBoxF4NET100.PriTextBoxF4)
                {
                    var txtPriTextBoxF4 = controls[0] as PriTextBoxF4NET100.PriTextBoxF4;
                    txtPriTextBoxF4.OpenListF4 += func_open_list;
                }
            }
            catch (Exception ex)
            {
                PSO.Dialogos.MostraAviso("ERRO ao inicializar o a lista f4: " + ex.Message);
            }
        }

        public static string GetEuroSymbol(double valor)
        {
            string convert = Convert.ToString(valor);

            if (!string.IsNullOrEmpty(convert))
            {
                convert += "€";
            }
                return convert;
        }

        public static string GetLSymbol(double valor)
        {
            string convert = Convert.ToString(valor);
            if (!string.IsNullOrEmpty(convert))
            {
                convert += "L";
            }
            return convert;
        }

        //public static string FormataValoresCentenas(double valor)
        //{
        //    string formatedValue = Convert.ToString(valor);

        //    int beforeDot = formatedValue.IndexOf(".", StringComparison.Ordinal);

        //    if (beforeDot > 0)
        //    {
        //        formatedValue.Substring(0, beforeDot);
        //    }

        //    for (int i = 0; i < formatedValue.Length; i++)
        //    {
        //        formatedValue 
        //    }
        //    return valor;
        //}
    }
}
