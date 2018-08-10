using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Azuli.Web.Model;
using System.Web;


namespace Azuli.Web.DAO
{
    public class ProprietarioDAO:AcessoDAO, Interfaces.IProprietario
    {
      
        #region IProprietario Members

        public int autenticaMorador(Model.ApartamentoModel ap)
        {

            string clausulaSQL = "AUTENTICA_MORADOR";

            populaProprietario(ap);

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", ap.bloco);
                comandoSQL.Parameters.AddWithValue("@SENHA", ap.oProprietario.senha);
                SqlParameter retornoLogin = new SqlParameter("@RETORNO", SqlDbType.Int);
                retornoLogin.Direction = ParameterDirection.Output;
                comandoSQL.Parameters.Add(retornoLogin);
                
                ExecutaComando(comandoSQL);

                return int.Parse(comandoSQL.Parameters["@RETORNO"].Value.ToString());
            }
            catch (Exception error)
            {

              
                throw error;
            }
        }

        


        public int CadastrarApartamentoMorador(Model.ProprietarioModel ap)
        {

            string clausulaSQL = "CADASTRA_MORADOR_APARTAMENTO";

           

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@BLOCO", ap.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", ap.ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@MORADOR1", ap.proprietario1);
                //comandoSQL.Parameters.AddWithValue("@MORADOR2", ap.proprietario2);
                comandoSQL.Parameters.AddWithValue("@email", ap.email);
                comandoSQL.Parameters.AddWithValue("@senha", ap.senha);
                comandoSQL.Parameters.AddWithValue("@telefone", ap.telefone);
                comandoSQL.Parameters.AddWithValue("@proprietarioImovel", ap.proprietarioImovel);
                SqlParameter retornoCadastro = new SqlParameter("@RETORNO", SqlDbType.Int);
                retornoCadastro.Direction = ParameterDirection.Output;
                comandoSQL.Parameters.Add(retornoCadastro);
                
                
                ExecutaComando(comandoSQL);

                return int.Parse(comandoSQL.Parameters["@RETORNO"].Value.ToString());
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void cadastraDepedentes(Depedentes dp, ApartamentoModel pAp)
        {

            string clausulaSQL = "CADASTRAR_DEPEDENTES";
            SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

            //Cadastro de depedentes
            comandoSQL.Parameters.AddWithValue("@NOME_DEPEDENTE", dp.nomeDepedente);
            comandoSQL.Parameters.AddWithValue("@PARENTESCO", dp.parentesco);
            comandoSQL.Parameters.AddWithValue("@DATA_NASC_DEPEDENTE", Convert.ToDateTime(dp.nascimentoDepedente));
            comandoSQL.Parameters.AddWithValue("@BLOCO", pAp.bloco);
            comandoSQL.Parameters.AddWithValue("@AP",pAp.apartamento );

            ExecutaComando(comandoSQL);

        }

        public void cadastraEmpregados(Empregados empregados, ApartamentoModel pAp)
        {

            string clausulaSQL = "CADASTRAR_EMPREGADOS";
            SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

            //Cadastro de empregados
            comandoSQL.Parameters.AddWithValue("@NOME_EMPREGADO", empregados.nomeEmpregado);
            comandoSQL.Parameters.AddWithValue("@RG_EMPREGADO", empregados.rgEmpregado);
            comandoSQL.Parameters.AddWithValue("@BLOCO", pAp.bloco);
            comandoSQL.Parameters.AddWithValue("@AP", pAp.apartamento);

            ExecutaComando(comandoSQL);

        }

        public void cadastraCarros(Transporte transporte, ApartamentoModel pAp)
        {

            string clausulaSQL = "CADASTRAR_CARROS";
            SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

            //Cadastro de Veiculos
            comandoSQL.Parameters.AddWithValue("@MARCA_MODELO", transporte.marcaModelo);
            comandoSQL.Parameters.AddWithValue("@COR", transporte.cor);
            comandoSQL.Parameters.AddWithValue("@PLACA", transporte.placaCarro);
            comandoSQL.Parameters.AddWithValue("@BLOCO", pAp.bloco);
            comandoSQL.Parameters.AddWithValue("@AP", pAp.apartamento);

            ExecutaComando(comandoSQL);

        }

        public void cadastraEmergencia(Emergencia emergencia, ApartamentoModel pAp)
        {

            string clausulaSQL = "CADASTRAR_EMERGENCIA";
            SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

            //Cadastro de contato de emergencia
            comandoSQL.Parameters.AddWithValue("@NOME_EMERGENCIA", emergencia.nomeContatoEmergencia);
            comandoSQL.Parameters.AddWithValue("@PARENTESCO_EMERGENCIA", emergencia.nomeParentescoEmergencia);
            comandoSQL.Parameters.AddWithValue("@CONTATO_EMERGENCIA", emergencia.contato);
            comandoSQL.Parameters.AddWithValue("@BLOCO", pAp.bloco);
            comandoSQL.Parameters.AddWithValue("@AP", pAp.apartamento);

            ExecutaComando(comandoSQL);

        }

        public void cadastraAnimais(Animais animais, ApartamentoModel pAp)
        {

            string clausulaSQL = "CADASTRAR_ANIMAIS";
            SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

            //Cadastro de animais
            comandoSQL.Parameters.AddWithValue("@QTD_ANIMAIS", animais.quantidadeAnimais);
            comandoSQL.Parameters.AddWithValue("@ESPECIES", animais.especies);
            comandoSQL.Parameters.AddWithValue("@BLOCO", pAp.bloco);
            comandoSQL.Parameters.AddWithValue("@AP", pAp.apartamento);
            ExecutaComando(comandoSQL);

        }

        public void cadastraImobiliaria(Imobiliaria imobiliaria, ApartamentoModel pAp)
        {

            string clausulaSQL = "CADASTRAR_IMOBILIARIA";
            SqlCommand comandoSQL = new SqlCommand(clausulaSQL);


            //Cadastro de imobiliaria
            comandoSQL.Parameters.AddWithValue("@NOME_IMOBILIARIA", imobiliaria.nomeImobiliaria);
            comandoSQL.Parameters.AddWithValue("@TELEFONE_IMOBILIARIA", imobiliaria.telefoneImobiliaria);
            comandoSQL.Parameters.AddWithValue("@CONTATO_IMOBILIARIA", imobiliaria.Contato);
            comandoSQL.Parameters.AddWithValue("@BLOCO", pAp.bloco);
            comandoSQL.Parameters.AddWithValue("@AP", pAp.apartamento);

            ExecutaComando(comandoSQL);

        }

        public int cadastrarApartamentoMoradorCompleto(Model.ProprietarioModel ap)
        {

            string clausulaSQL = "CADASTRA_MORADOR_APARTAMENTO";



            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                //Cadastro de Morador
                comandoSQL.Parameters.AddWithValue("@BLOCO", ap.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", ap.ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@MORADOR1", ap.proprietario1);
                comandoSQL.Parameters.AddWithValue("@email", ap.email);
                comandoSQL.Parameters.AddWithValue("@senha", ap.senha);
                comandoSQL.Parameters.AddWithValue("@telefone", ap.telefone);
                comandoSQL.Parameters.AddWithValue("@proprietarioImovel", ap.proprietarioImovel);
                comandoSQL.Parameters.AddWithValue("@cpf", ap.cpf);
                comandoSQL.Parameters.AddWithValue("@rg", ap.rg);
                comandoSQL.Parameters.AddWithValue("@estadoCivil", ap.estadoCivil);
                comandoSQL.Parameters.AddWithValue("@celular", ap.celular);
                comandoSQL.Parameters.AddWithValue("@cep", ap.cepEndereco);
                comandoSQL.Parameters.AddWithValue("@bairro", ap.bairro);
                comandoSQL.Parameters.AddWithValue("@endereco", ap.endereco);
                comandoSQL.Parameters.AddWithValue("@cidade", ap.cidade);
                comandoSQL.Parameters.AddWithValue("@alugaGaragem", ap.alugaGaragem);
                comandoSQL.Parameters.AddWithValue("@qtdBike", ap.qtdBicicleta);
                comandoSQL.Parameters.AddWithValue("@descricaoBike", ap.descricaoBike);
                comandoSQL.Parameters.AddWithValue("@qtdGaragem", ap.ap.qtdGaragem);


                SqlParameter retornoCadastro = new SqlParameter("@RETORNO", SqlDbType.Int);
                retornoCadastro.Direction = ParameterDirection.Output;
                comandoSQL.Parameters.Add(retornoCadastro);


                ExecutaComando(comandoSQL);

                foreach (Depedentes depedentes in ap.dependentes)
                {
                    cadastraDepedentes(depedentes, ap.ap);
                   
                }

                foreach (Empregados empregado in ap.empregados)
                {
                    cadastraEmpregados(empregado, ap.ap);
                }


                foreach (Transporte transporte in ap.transporte)
                {
                    cadastraCarros(transporte, ap.ap);
                }

                if (ap.emergencia != null)
                {
                    cadastraEmergencia(ap.emergencia, ap.ap);
                }

                if (ap.animais != null)
                {
                    cadastraAnimais(ap.animais, ap.ap);
                }


                if (ap.imobiliaria != null)
                {
                    cadastraImobiliaria(ap.imobiliaria, ap.ap);
                }
               

               

                return int.Parse(comandoSQL.Parameters["@RETORNO"].Value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string BuscaEmailMorador(ApartamentoModel ap)
        {
            string clausulaSQL = "SP_BUSCA_EMAIL";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@VALOR_APTO", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@VALOR_BLOCO", ap.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return GetEmail(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        
        }





        public listProprietario BuscaMoradorAdmin(ApartamentoModel ap)
        {
            string clausulaSQL = "BUSCA_MORADOR_ADMIN";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", ap.bloco);
       
                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaAp(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public listProprietario enviaCrendencialAcesso(ApartamentoModel oPropri)
        {
            string clausulaSQL = "SP_ENVIA_SENHA_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", oPropri.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", oPropri.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaAp(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }

    
        public void liberaAcesso(ApartamentoModel ap)
        {
            string clausulaSQL = "SP_LIBERA_ACESSO_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", ap.bloco);
                ExecutaQuery(comandoSQL);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void alteraSenha(ProprietarioModel oProprietario)
        {
            string clausulaSQL = "ALTERA_SENHA";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", oProprietario.ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", oProprietario.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@NOVA_SENHA", oProprietario.senha);

                ExecutaQuery(comandoSQL);

            }
            catch (Exception e) 
            {

                throw e;
            }


        }



        public Model.listProprietario listaAp(DataTable dt)
        {
            listProprietario oListProprietario = new listProprietario();

            foreach (DataRow dr in dt.Rows)
            {
                ProprietarioModel oPropri = new ProprietarioModel();
                oPropri.ap = new ApartamentoModel();

                if (dr.Table.Columns.Contains("NOME_PROPRIETARIO1"))
                    oPropri.proprietario1 = dr["NOME_PROPRIETARIO1"].ToString();
               
                if (dr.Table.Columns.Contains("NOME_PROPRIETARIO2"))
                    oPropri.proprietario2 = dr["NOME_PROPRIETARIO2"].ToString();

                oPropri.ap.bloco = int.Parse(dr["PROPRIETARIO_BLOCO"].ToString());
                
                oPropri.ap.apartamento = int.Parse(dr["PROPRIETARIO_AP"].ToString());

                if (dr.Table.Columns.Contains("email") && !Convert.IsDBNull(dr["email"]))
                    oPropri.email = dr["email"].ToString();

                if (dr.Table.Columns.Contains("PASSWORD") && !Convert.IsDBNull(dr["email"]))
                    oPropri.senha = dr["PASSWORD"].ToString();

                if (dr.Table.Columns.Contains("TELEFONE") && !Convert.IsDBNull(dr["email"]))
                    oPropri.telefone = dr["TELEFONE"].ToString();

                if (dr.Table.Columns.Contains("PROPRIETARIO_IMOVEL") && !Convert.IsDBNull(dr["email"]))
                    oPropri.proprietarioImovel = dr["PROPRIETARIO_IMOVEL"].ToString();

                if (dr.Table.Columns.Contains("QUANTIDADE_GARAGEM") && !Convert.IsDBNull(dr["QUANTIDADE_GARAGEM"]))
                    oPropri.ap.qtdGaragem = int.Parse(dr["QUANTIDADE_GARAGEM"].ToString());

                if (dr.Table.Columns.Contains("CPF") && !Convert.IsDBNull(dr["CPF"]))
                    oPropri.cpf = dr["CPF"].ToString();

                if (dr.Table.Columns.Contains("RG") && !Convert.IsDBNull(dr["RG"]))
                    oPropri.rg = dr["RG"].ToString();

                if (dr.Table.Columns.Contains("CELULAR") && !Convert.IsDBNull(dr["CELULAR"]))
                    oPropri.celular = dr["CELULAR"].ToString();

                if (dr.Table.Columns.Contains("ESTADO_CIVIL") && !Convert.IsDBNull(dr["ESTADO_CIVIL"]))
                    oPropri.estadoCivil = dr["ESTADO_CIVIL"].ToString();

                if (dr.Table.Columns.Contains("CEP") && !Convert.IsDBNull(dr["CEP"]))
                    oPropri.cepEndereco = dr["CEP"].ToString();

                if (dr.Table.Columns.Contains("ENDERECO") && !Convert.IsDBNull(dr["ENDERECO"]))
                    oPropri.endereco = dr["ENDERECO"].ToString();

                if (dr.Table.Columns.Contains("CIDADE") && !Convert.IsDBNull(dr["CIDADE"]))
                    oPropri.cidade = dr["CIDADE"].ToString();

                if (dr.Table.Columns.Contains("BAIRRO") && !Convert.IsDBNull(dr["BAIRRO"]))
                    oPropri.bairro = dr["BAIRRO"].ToString();

                if (dr.Table.Columns.Contains("ALUGA_GARAGEM") && !Convert.IsDBNull(dr["ALUGA_GARAGEM"]))
                    oPropri.alugaGaragem = dr["ALUGA_GARAGEM"].ToString();

                if (dr.Table.Columns.Contains("BICICLETAS_QUANTIDADE") && !Convert.IsDBNull(dr["BICICLETAS_QUANTIDADE"]))
                    oPropri.qtdBicicleta = int.Parse(dr["BICICLETAS_QUANTIDADE"].ToString());

                if (dr.Table.Columns.Contains("DESCRICAO_BICICLETAS") && !Convert.IsDBNull(dr["DESCRICAO_BICICLETAS"]))
                    oPropri.descricaoBike = dr["DESCRICAO_BICICLETAS"].ToString();

                 oPropri.dependentes =  listaDeDepedentes(oPropri.ap);
                 oPropri.empregados = listaDeEmpregados(oPropri.ap);
                 oPropri.transporte = listaDeTransporte(oPropri.ap);
                 oPropri.emergencia = contatoEmergenciaMorador(oPropri.ap);
                 oPropri.animais = getAnimaisMorador(oPropri.ap);
                 oPropri.imobiliaria = getImobiliariaMorador(oPropri.ap);
                oListProprietario.Add(oPropri);

            }

            return oListProprietario;
        }
       
 





        public listProprietario populaProprietario(ApartamentoModel ap)
        {
            string clausulaSQL = "POPULA_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", ap.bloco);
                comandoSQL.Parameters.AddWithValue("@SENHA", ap.oProprietario.senha);
                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaAp(tbProprietario);


            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public listProprietario populaProprietarioSemSenha(ApartamentoModel ap)
            {
            string clausulaSQL = "POPULA_MORADOR_SEM_SENHA";

            try
                {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", ap.bloco);
                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }
            }

      
        listApartamento Interfaces.IProprietario.listaAp(DataTable dt)
        {
            throw new NotImplementedException();
        }

     

        


        public void cadastraOcorrencia(LancamentoOcorrenciaModel olacamento)
        {
             string clausulaSQL ="CADASTRA_OCORRENCIA";

             try
             {
                 
                 SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                 comandoSQL.Parameters.AddWithValue("@DATA_CADASTRO", olacamento.dataOcorrencia);
                 comandoSQL.Parameters.AddWithValue("@STATUS", olacamento.statusOcorrencia);
                 comandoSQL.Parameters.AddWithValue("@DESCRICAO", olacamento.descricaoOcorrencia);
                 comandoSQL.Parameters.AddWithValue("@BLOCO", olacamento.oAp.bloco);
                 comandoSQL.Parameters.AddWithValue("@AP", olacamento.oAp.apartamento);
                 comandoSQL.Parameters.AddWithValue("@DATA_RESOLUCAO", olacamento.dataOcorrencia);
                 comandoSQL.Parameters.AddWithValue("@DATA_CANCEL", olacamento.dataCancelamento);
                 comandoSQL.Parameters.AddWithValue("@CAMINHO_IMAGEM_EVIDENCIA", olacamento.imagemEvidencia);
                 comandoSQL.Parameters.AddWithValue("@TIPO_OCORRENCIA", olacamento.oOcorrencia.codigoOcorencia);
                
                 ExecutaComando(comandoSQL);

             }
             catch (Exception)
             {
                 
                 throw;
             }
            
        }

       


        public listProprietario recuperaSenhaMorador(ProprietarioModel ap)
        {
            string clausulaSQL = "RECUPERA_SENHA_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", ap.ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", ap.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@EMAIL", ap.email);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaAp(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public listProprietario PesquisaMorador(string tipo_busca, string pesquisa_nome, ApartamentoModel ap)
        {
            string clausulaSQL = "SP_BUSCA_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@TIPO_BUSCA", tipo_busca);
                comandoSQL.Parameters.AddWithValue("@BUSCA_NOME", pesquisa_nome);
                comandoSQL.Parameters.AddWithValue("@VALOR_APTO", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@VALOR_BLOCO", ap.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaAp(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public listProprietario listaProprietarioSendEmail()
        {

            string clausulaSQL = "SP_MORADOR_ENVIA_EMAIL_RECIBO";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaApSendReciboByEmail(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<Depedentes> listaDeDepedentes(ApartamentoModel pAp)
            {

            string clausulaSQL = "POPULA_DEPEDENTE";

            try
                {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", pAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", pAp.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return buscaDepedentesByBlocoAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }

            }


        public List<Empregados> listaDeEmpregados(ApartamentoModel pAp)
            {

            string clausulaSQL = "POPULA_EMPREGADO";

            try
                {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", pAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", pAp.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return buscaEmpregadosByBlocoAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }

            }

        public Emergencia contatoEmergenciaMorador(ApartamentoModel pAp)
            {

            string clausulaSQL = "POPULA_EMERGENCIA";

            try
                {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", pAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", pAp.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return buscaContatoEmergenciaByBlocoAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }

            }


        public Animais getAnimaisMorador(ApartamentoModel pAp)
            {

            string clausulaSQL = "POPULA_ANIMAIS";

            try
                {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", pAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", pAp.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return buscaAnimaisByBlocoAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }

            }


        public Imobiliaria getImobiliariaMorador(ApartamentoModel pAp)
            {

            string clausulaSQL = "POPULA_IMOBILIARIA";

            try
                {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", pAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", pAp.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return buscaImobiliariaByBlocoAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }

            }

        
        
        public List<Transporte> listaDeTransporte(ApartamentoModel pAp)
            {

            string clausulaSQL = "POPULA_TRANSPORTE";

            try
                {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_AP", pAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@PROPRIETARIO_BLOCO", pAp.bloco);

                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return buscaTransporteByBlocoAp(tbProprietario);


                }
            catch (Exception)
                {

                throw;
                }

            }



        public Model.listProprietario listaApSendReciboByEmail(DataTable dt)
        {
            listProprietario oListProprietario = new listProprietario();

            foreach (DataRow dr in dt.Rows)
            {
                ProprietarioModel oPropri = new ProprietarioModel();
                oPropri.ap = new ApartamentoModel();

                if (dr.Table.Columns.Contains("NOME_PROPRIETARIO1") && !Convert.IsDBNull(dr["NOME_PROPRIETARIO1"]))
                    oPropri.proprietario1 = dr["NOME_PROPRIETARIO1"].ToString();

                if (dr.Table.Columns.Contains("PROPRIETARIO_BLOCO") && !Convert.IsDBNull(dr["PROPRIETARIO_BLOCO"]))
                    oPropri.ap.bloco = Convert.ToInt32(dr["PROPRIETARIO_BLOCO"]);

                if (dr.Table.Columns.Contains("PROPRIETARIO_AP") && !Convert.IsDBNull(dr["PROPRIETARIO_AP"]))
                    oPropri.ap.apartamento = Convert.ToInt32(dr["PROPRIETARIO_AP"]);

                if (dr.Table.Columns.Contains("email") && !Convert.IsDBNull(dr["email"]))
                    oPropri.email = dr["email"].ToString();

                oListProprietario.Add(oPropri);

            }

            return oListProprietario;
        }


        public List<Depedentes> buscaDepedentesByBlocoAp(DataTable dt)
            {
             List<Depedentes> oListDepedente = new List<Depedentes>();

            foreach (DataRow dr in dt.Rows)
                {
                Depedentes oDepedente = new Depedentes();


                if (dr.Table.Columns.Contains("NOME") && !Convert.IsDBNull(dr["NOME"]))
                    oDepedente.nomeDepedente = dr["NOME"].ToString();

                if (dr.Table.Columns.Contains("PARENTESCO") && !Convert.IsDBNull(dr["PARENTESCO"]))
                    oDepedente.parentesco = dr["PARENTESCO"].ToString();

                if (dr.Table.Columns.Contains("DATA_NASC") && !Convert.IsDBNull(dr["DATA_NASC"]))
                    oDepedente.nascimentoDepedente = dr["DATA_NASC"].ToString();

                oListDepedente.Add(oDepedente);

                }

            return oListDepedente;
            }


        public List<Empregados> buscaEmpregadosByBlocoAp(DataTable dt)
            {
            List<Empregados> oListEmpregados = new List<Empregados>();

            foreach (DataRow dr in dt.Rows)
                {
                Empregados oEmpregado = new Empregados();


                if (dr.Table.Columns.Contains("NOME") && !Convert.IsDBNull(dr["NOME"]))
                    oEmpregado.nomeEmpregado = dr["NOME"].ToString();

                if (dr.Table.Columns.Contains("RG") && !Convert.IsDBNull(dr["RG"]))
                    oEmpregado.rgEmpregado = dr["RG"].ToString();



                oListEmpregados.Add(oEmpregado);

                }

            return oListEmpregados;
            }



        public Emergencia buscaContatoEmergenciaByBlocoAp(DataTable dt)
            {

            Emergencia oEmergencia = new Emergencia();

            foreach (DataRow dr in dt.Rows)
                {
                


                if (dr.Table.Columns.Contains("NOME_EMERGENCIA") && !Convert.IsDBNull(dr["NOME_EMERGENCIA"]))
                    oEmergencia.nomeContatoEmergencia = dr["NOME_EMERGENCIA"].ToString();

                if (dr.Table.Columns.Contains("PARENTESCO_EMERGENCIA") && !Convert.IsDBNull(dr["PARENTESCO_EMERGENCIA"]))
                    oEmergencia.nomeParentescoEmergencia = dr["PARENTESCO_EMERGENCIA"].ToString();

                if (dr.Table.Columns.Contains("CONTATO") && !Convert.IsDBNull(dr["CONTATO"]))
                    oEmergencia.contato = dr["CONTATO"].ToString();

                }

            return oEmergencia;
            }


        public Imobiliaria buscaImobiliariaByBlocoAp(DataTable dt)
            {

            Imobiliaria oImobiliaria = new Imobiliaria();

            foreach (DataRow dr in dt.Rows)
                {

                if (dr.Table.Columns.Contains("NOME_IMOBILIARIA") && !Convert.IsDBNull(dr["NOME_IMOBILIARIA"]))
                    oImobiliaria.nomeImobiliaria = dr["NOME_IMOBILIARIA"].ToString();

                if (dr.Table.Columns.Contains("TELEFONE_IMOBILIARIA") && !Convert.IsDBNull(dr["TELEFONE_IMOBILIARIA"]))
                    oImobiliaria.telefoneImobiliaria = dr["TELEFONE_IMOBILIARIA"].ToString();

                if (dr.Table.Columns.Contains("CONTATO") && !Convert.IsDBNull(dr["CONTATO"]))
                    oImobiliaria.Contato = dr["CONTATO"].ToString();

                }

            return oImobiliaria;
            }



        public Animais buscaAnimaisByBlocoAp(DataTable dt)
            {

            Animais oAnimais = new Animais();

            foreach (DataRow dr in dt.Rows)
                {

                if (dr.Table.Columns.Contains("QUANTIDADE") && !Convert.IsDBNull(dr["QUANTIDADE"]))
                    oAnimais.quantidadeAnimais = int.Parse(dr["QUANTIDADE"].ToString());

                if (dr.Table.Columns.Contains("ESPECIES") && !Convert.IsDBNull(dr["ESPECIES"]))
                    oAnimais.especies = dr["ESPECIES"].ToString();

                }

            return oAnimais;
            }



        public List<Transporte> buscaTransporteByBlocoAp(DataTable dt)
            {
            List<Transporte> oListTransporte = new List<Transporte>();

            foreach (DataRow dr in dt.Rows)
                {
                Transporte oTransporte = new Transporte();


                if (dr.Table.Columns.Contains("MARCA_MODELO") && !Convert.IsDBNull(dr["MARCA_MODELO"]))
                    oTransporte.marcaModelo = dr["MARCA_MODELO"].ToString();

                if (dr.Table.Columns.Contains("COR") && !Convert.IsDBNull(dr["COR"]))
                    oTransporte.cor = dr["COR"].ToString();

                if (dr.Table.Columns.Contains("PLACA") && !Convert.IsDBNull(dr["PLACA"]))
                    oTransporte.placaCarro = dr["PLACA"].ToString();

                oListTransporte.Add(oTransporte);

                }

            return oListTransporte;
            }




        public string GetEmail(DataTable dt)
        {
            string email = "";

            foreach (DataRow dr in dt.Rows)
            {
                

                if (dr.Table.Columns.Contains("email"))
                    email = dr["email"].ToString();




            }

            return email;
        }
       


#endregion




        int Interfaces.IProprietario.autenticaMorador(ApartamentoModel ap)
        {
            throw new NotImplementedException();
        }

        listProprietario Interfaces.IProprietario.populaProprietario(ApartamentoModel ap, ProprietarioModel apPro)
        {
            throw new NotImplementedException();
        }

        listProprietario Interfaces.IProprietario.BuscaMoradorAdmin(ApartamentoModel ap)
        {
            throw new NotImplementedException();
        }

        int Interfaces.IProprietario.CadastrarApartamentoMorador(ProprietarioModel ap)
        {
            throw new NotImplementedException();
        }

        void Interfaces.IProprietario.alteraSenha(ProprietarioModel oProprietario)
        {
            throw new NotImplementedException();
        }

        void Interfaces.IProprietario.cadastraOcorrencia(LancamentoOcorrenciaModel olacamento)
        {
            throw new NotImplementedException();
        }

        listProprietario Interfaces.IProprietario.recuperaSenhaMorador(ProprietarioModel ap)
        {
            throw new NotImplementedException();
        }

        void Interfaces.IProprietario.liberaAcesso(ApartamentoModel ap)
        {
            throw new NotImplementedException();
        }

        listProprietario Interfaces.IProprietario.enviaCrendencialAcesso(ApartamentoModel oPropri)
        {
            throw new NotImplementedException();
        }

        listProprietario Interfaces.IProprietario.PesquisaMorador(string tipo_busca, string pesquisa_nome, ApartamentoModel ap)
        {
            throw new NotImplementedException();
        }

        string Interfaces.IProprietario.BuscaEmailMorador(ApartamentoModel ap)
        {
            throw new NotImplementedException();
        }
    }
}
