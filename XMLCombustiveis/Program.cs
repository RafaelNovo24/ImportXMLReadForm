using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLCombustiveis
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.Default;

                string filepath = @"C:\Users\Rafael Novo\Desktop\Empresas\RDSM Recauchutagem\XMLCombustiveis\";
                string createPath = filepath + "CarregarXML";
                string DestPath = filepath + "Documentos Verificados";

                Console.ReadLine();

                if (!Directory.Exists(createPath))
                {
                    System.IO.Directory.CreateDirectory(createPath);
                }

                if (!Directory.Exists(DestPath))
                {
                    System.IO.Directory.CreateDirectory(DestPath);
                }

                XmlDocument xdoc = new XmlDocument();

                string[] files = Directory.GetFiles(createPath)
                                              .Where(p => p.EndsWith(".xml"))
                                              .ToArray();

                if (files.Count() <= 0)
                {
                   // Console.WriteLine("sem ficheiros");
                    return;
                }

                foreach (var path in files)
                {
                    string filename = GetFilename(path);

                    string destino = @"C:\Users\Rafael Novo\Desktop\Empresas\RDSM Recauchutagem\XMLCombustiveis\Documentos Verificados\" + filename;

                    if (File.Exists(destino))
                    {
                        //Console.WriteLine("************ Este ficheiro já foi importado. ************");
                        //Console.WriteLine(path);

                        continue;
                    }

                    xdoc.Load(path);

                    bool flag;
                    if (args.Count() > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }

                    if (LerXML(path, flag))
                    {
                        File.Move(path, destino);
                    }
                    else
                    {
                        //Console.WriteLine("sem ficheiros");
                        goto certeza;                     
                    }
                }

                Console.Write("sucesso");
                return;

                certeza:
                Console.Write("certeza");
                return;
                semFicheiros:
                Console.Write("sem ficheiros");
                return;  
            }
            catch (Exception)
            {
                Console.Write("erro");
            }
        }

        private static bool LerXML(string filepath, bool force)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filepath);

            string posto;

            //Procurar o posto de abastecimento
            XmlNode nodePosto = xdoc.SelectSingleNode(" / Transaction");
            posto = nodePosto.Attributes["SiteID"].Value.ToString().Trim();

            //Verificar se o node HE_NORMAL existe
            string data = "";
            XmlNode nodeData = xdoc.SelectSingleNode("/Transaction/IXHeader/HE_NORMAL");
            if (nodeData != null)
            {
                //Procurar a data do XML
                data = nodeData.Attributes["TicketDateTime"].Value.ToString();

                if (data != "")
                {
                    data = FormatData(data);
                }
            }
            else
            {
                nodeData = xdoc.SelectSingleNode("/Transaction/IXHeader/HE_SIGNOFF");

                if (nodeData == null)
                {
                    return false;
                }
                else
                {
                    //Procurar a data do XML
                    data = nodeData.Attributes["TicketDateTime"].Value.ToString();

                    if (data != "")
                    {
                        data = FormatData(data);
                    }
                }
            }


            //Procurar Tipos de Gasolina
            List<Gasolina> tipoGasolina = new List<Gasolina>();
            XmlNodeList nodeListGradeMode = xdoc.SelectNodes("/Transaction/IXGradeMode/WD_GRADEMODE"); //WD_GRADEMODE

            if (nodeListGradeMode.Count == 0)
            {
                nodeListGradeMode = xdoc.SelectNodes("/Transaction/IXGradeMode/EOD_GRADEMODE");

                if (nodeListGradeMode.Count == 0)
                {
                    return false;
                }
            }

            var con = AbrirDB();

            foreach (XmlNode nodeGradeMode in nodeListGradeMode)
            {
                Gasolina detalhes = new Gasolina();

                detalhes.TipoGasolina = nodeGradeMode.Attributes["GradeText"].Value.ToString().Trim();
                detalhes.PrecUnit = Convert.ToDecimal(nodeGradeMode.Attributes["UnitPrice"].Value.ToString().Replace(".", ","));
                detalhes.VolumeTotal = Convert.ToDecimal(nodeGradeMode.Attributes["VolumeTotal"].Value.ToString().Replace(".", ","));
                detalhes.QuantidadeTotal = Convert.ToDecimal(nodeGradeMode.Attributes["AmountTotal"].Value.ToString().Replace(".", ","));
                tipoGasolina.Add(detalhes);

                if (force == false)
                {
                    if (VerificarSeRepete(posto, data) == false)
                    {
                        //Console.WriteLine("certeza");                      
                        return false;
                    }
                }

                PreencherDetalhesDiarios(detalhes, Convert.ToDateTime(data), posto);

                Dapper.SqlMapper.ExecuteScalar(con, $@"Insert into TDU_ValoresTotais(CDU_TipoGasolina, CDU_Posto, CDU_DataInfo, CDU_PrecUnit, CDU_ValorTotal, CDU_LitrosTotal, CDU_ID)
                                                    Values('{detalhes.TipoGasolina}', '{posto}', '{data}', 
                                                    {detalhes.PrecUnit.ToString("0.000").Replace(",", ".")}, 
                                                    {detalhes.QuantidadeTotal.ToString("0.000").Replace(",", ".")}, 
                                                    {detalhes.VolumeTotal.ToString("0.000").Replace(",", ".")}, (select NEWID()))");

                string sqlQuery = "";


                if (detalhes.VolumeDiario == 0 || detalhes.QuantidadeDiaria == 0)
                {
                    sqlQuery = $@"insert into TDU_DetalhesTotais ( CDU_TipoGasolina, CDU_Posto , CDU_VolumeDiario, CDU_QuantidadeDiaria, CDU_Data) 
                                  values ( '{detalhes.TipoGasolina}', '{posto.Trim()}' , 0 , 0 , '{data}')";
                }
                else if (detalhes.QuantidadeDiaria == 0)
                {
                    sqlQuery = $@"insert into TDU_DetalhesTotais ( CDU_TipoGasolina, CDU_Posto, CDU_VolumeDiario, CDU_QuantidadeDiaria, CDU_Data) 
                                  values ( '{detalhes.TipoGasolina}', '{posto.Trim()}' , {detalhes.VolumeDiario.ToString().Replace(",", ".")} , 0 , '{data}')";
                }
                else if (detalhes.VolumeDiario == 0)
                {
                    sqlQuery = $@"insert into TDU_DetalhesTotais ( CDU_TipoGasolina, CDU_Posto , CDU_VolumeDiario, CDU_QuantidadeDiaria, CDU_Data) 
                                  values ( '{detalhes.TipoGasolina}', '{posto.Trim()}' , 0 , {detalhes.QuantidadeDiaria.ToString().Replace(",", ".")}, '{data}')";

                }
                else
                {
                    sqlQuery = $@"insert into TDU_DetalhesTotais ( CDU_TipoGasolina, CDU_Posto , CDU_VolumeDiario, CDU_QuantidadeDiaria, CDU_Data) 
                                   values('{detalhes.TipoGasolina}' , '{posto.Trim()}' , {detalhes.VolumeDiario.ToString().Replace(",", ".")} ,
                                           {detalhes.QuantidadeDiaria.ToString().Replace(",", ".")} , '{data}')";
                }

                Dapper.SqlMapper.ExecuteScalar(con, sqlQuery);

            }

            con.Close();

            //Mostrar na consola
            //Console.WriteLine();
            //Console.WriteLine(filepath);
            //Console.WriteLine("Posto nº: " + posto);
            //Console.WriteLine("Data: " + data);

            //for (int i = 0; i < tipoGasolina.Count; i++)
            //{

            //    Console.WriteLine(tipoGasolina[i]);
            //}

            return true;
        }

        private static string FormatData(string data)
        {
            data = data.Insert(4, "/");
            data = data.Insert(7, "/");
            data = data.Substring(0, 10).Trim();
            //data = data.Insert(10, " ");
            //data = data.Insert(13, ":");
            //data = data.Insert(16, ":");

            return data;
        }

        private static string GetFilename(string path)
        {
            string name = "";
            int index = path.IndexOf("EXP_");
            int finalIndex = -(index - path.Length);
            name = path.Substring(index, finalIndex);

            return name;
        }

        private static SqlConnection AbrirDB()
        {
            var datasource = @"LAPTOP-BAETQR6A\SQLEXPRESS";//your server
            var database = "PRIRMREC"; //your database name
            var username = "sa"; //username of server to connect
            var password = "Sa12345678"; //password

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        private static Gasolina PreencherDetalhesDiarios(Gasolina Combustivel, DateTime Data, string Posto)
        {
            // Preencher os detalhes diários de cada tipo de gasolina
            var con = AbrirDB();

            DateTime dataPesquisa = Data.AddDays(-1);

            var combAnterior = Dapper.SqlMapper.Query<Gasolina>(con, $@"select top 1 CDU_TipoGasolina as TipoGasolina, CDU_PrecUnit as PrecUnit, CDU_LitrosTotal as VolumeTotal, CDU_ValorTotal as QuantidadeTotal from TDU_ValoresTotais
                                                                                where CDU_TipoGasolina = '{Combustivel.TipoGasolina.Trim()}' and
                                                                                      CDU_Posto = '{Posto.Trim()}' and
                                                                                      CDU_DataInfo = '{dataPesquisa.ToString("yyyy/MM/dd")}'").FirstOrDefault();

            if (combAnterior == null)
            {
                Combustivel.VolumeDiario = 0;
                Combustivel.QuantidadeDiaria = 0;

                return Combustivel;
            }

            Combustivel.QuantidadeDiaria = Combustivel.QuantidadeTotal - combAnterior.QuantidadeTotal;
            Combustivel.VolumeDiario = Combustivel.VolumeTotal - combAnterior.VolumeTotal;

            return Combustivel;
        }

        private static bool VerificarSeRepete(string Posto, string Data)
        {
            //Verifica se os dados daquele dia já foram inseridos
            var con = AbrirDB();

            var lista = Dapper.SqlMapper.Query<string>(con, $@"select CDU_DataInserido from TDU_ValoresTotais
                                    where CDU_Posto = '{Posto}'  and CDU_DataInfo = '{Data}'").ToList();

            if (lista.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}

