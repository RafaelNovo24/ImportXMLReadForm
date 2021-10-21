using StdBE100;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using RDSM.Util;

namespace RDSM.Forms
{
    public partial class frm_Combustivel : Form
    {
        public StdPlatBS100.StdBSInterfPub PSO;
        public ErpBS100.ErpBS BSO;

        public frm_Combustivel()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ImportarDados();
        }

        private static string abrirDialogoProcurarFicheiro()
        {
            try
            {
                string filePath = @"C:\";

                OpenFileDialog dia = new OpenFileDialog();

                dia.InitialDirectory = filePath;
                dia.Filter = "Excel Files| *.xls; *.xlsx; *.xlsm";
                dia.RestoreDirectory = true;

                if (dia.ShowDialog() == DialogResult.OK)
                {
                    var filestream = dia.OpenFile();
                }

                filePath = dia.FileName;
                return filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
                return "erro";
            }
        }

        private void ImportarDados()
        {
            string output = ChamarExeXml(false);

            if (output.ToLower() == "sucesso")
            {
                MessageBox.Show("Importado com sucesso.", "Sucesso");
            }
            else if (output.ToLower() == "erro")
            {
                MessageBox.Show("Ocorreu um erro ao importar os ficheiros.", "Erro");
            }
            else if (output.ToLower() == "sem ficheiros" || output.ToLower() == "")
            {
                MessageBox.Show("Não há ficheiros para importar.", "Atenção");
            }
            else if (output.ToLower() == "certeza")
            {
                if (MessageBox.Show("Já existem dados com esta data. Quer substituir?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    output = ChamarExeXml(true);
                }
                else
                {
                    return;
                }
            }
        }

        private void frm_Combustivel_Load(object sender, EventArgs e)
        {
            // Util.Utils.init_txtf4(PSO, ctrTipoCombustivel, F4TipoCombustivel);
            cmbTipoComb.Text = "Escolha um combustível";

            StdBELista lista = BSO.Consulta("select distinct CDU_TipoGasolina from TDU_ValoresTotais");

            while (!lista.NoFim())
            {
                cmbTipoComb.Items.Add(lista.Valor("CDU_TipoGasolina"));
                lista.Seguinte();
            }

            cmbTipoComb.Items.Add("Todos os tipos");
            cmbTipoComb.ValueMember = "CDU_TipoGasolina";
            cmbTipoComb.DisplayMember = "CDU_TipoGasolina";

            dtpDataInicial.Value = Convert.ToDateTime("01/01/" + DateTime.Now.Year.ToString());
            dtPDataFinal.Value = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void frm_Combustivel_Enter(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            dtGridDados.Rows.Clear();

            StdBELista lista;
            string sqlQuery;
            string posto;
            string data1 = dtpDataInicial.Value.ToString("dd/MM/yyyy");
            string data2 = dtPDataFinal.Value.ToString("dd/MM/yyyy");
            string tipoGasolina = "";


            sqlQuery = $@"select distinct FORMAT(CDU_DataInfo, 'dd/MM/yyyy') 'Data' , v.CDU_Posto 'Posto' , v.CDU_TipoGasolina 'TipoGasolina' , 
                            CONVERT(DECIMAL(10,3),CDU_PrecUnit) 'PUn' , CDU_ValorTotal 'ValorTotal', d.CDU_QuantidadeDiaria 'ValorDiario',
                            CDU_LitrosTotal 'LitrosTotal', d.CDU_VolumeDiario 'LitrosDiarios'
                            from TDU_ValoresTotais v
                            inner join TDU_DetalhesTotais d on v.CDU_TipoGasolina = d.CDU_TipoGasolina 
                            where FORMAT(CDU_DataInfo, 'dd/MM/yyyy') between '{data1}' and '{data2}'";



            if (!string.IsNullOrEmpty(txtPosto.Text))
            {
                posto = $" and v.CDU_Posto = '{txtPosto.Text}'";
                sqlQuery += posto;
            }

            if (cmbTipoComb.SelectedIndex != -1)
            {
                if (cmbTipoComb.SelectedItem.ToString() == "Todos os tipos")
                {
                    tipoGasolina = "";
                }
                else
                {
                    tipoGasolina = cmbTipoComb.SelectedItem.ToString();
                    sqlQuery += $" and v.CDU_TipoGasolina= '{tipoGasolina}'";
                }
            }

            sqlQuery += " \r\n order by Data, Posto, [TipoGasolina]";

            lista = BSO.Consulta(sqlQuery);

            while (!lista.NoFim())
            {
                string PUn1 = lista.Valor(3);
                string PUn = Utils.GetEuroSymbol(lista.Valor(3));
                string valorTotal = Utils.GetEuroSymbol(lista.Valor(4));
                string valorDiario = Utils.GetEuroSymbol(lista.Valor(5));
                string LitrosTotal = Utils.GetLSymbol(lista.Valor(6));
                string LitrosDiarios = Utils.GetLSymbol(lista.Valor(7));

                dtGridDados.Rows.Add(lista.Valor(0), lista.Valor(1), lista.Valor(2), PUn, valorTotal, valorDiario, LitrosTotal, LitrosDiarios);

                var teste = lista.Valor(7);
                lista.Seguinte();
            }

            //dtGridDados.DataSource = lista.DataSet.Tables[0].Copy();

            dtGridDados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridDados.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridDados.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridDados.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridDados.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridDados.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridDados.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dtGridDados.Columns[1].Width = 70;
            //dtGridDados.Columns[2].Width = 250;
            //dtGridDados.Columns[3].Width = 70;
            //dtGridDados.Columns[4].Width = 100;
            //dtGridDados.Columns[5].Width = 100;
            //dtGridDados.Columns[6].Width = 100;
            //dtGridDados.Columns[7].Width = 100;



        }

        private void cmbTipoComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static string ChamarExeXml(bool force)
        {
            var process = new System.Diagnostics.Process();

            process.StartInfo.FileName = @"C:\Users\Rafael Novo\Desktop\Empresas\RDSM Recauchutagem\RDSM\Util\CarregarXML\XMLCombustiveis.exe";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            if (force)
            {
                process.StartInfo.Arguments = "force";
            }

            process.Start();

            string resultado = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            return resultado;
        }

        private void txtPosto_Enter(object sender, EventArgs e)
        {
            Pesquisar();
        }

    }
}
