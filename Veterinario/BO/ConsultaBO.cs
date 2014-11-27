using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinario.DA;
using Veterinario.TO;

namespace Veterinario.BO
{

    public class ConsultaBO
    {
        //Cria o objeto da BaseCRUD
        BaseCRUD<Consulta> da = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">Consulta</param>
        /// <returns>Consulta</returns>
        public Consulta Inserir(Consulta registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Consulta>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (registro.DataHora == DateTime.MinValue)
                {
                    msgErro.AppendLine("Data e hora da consulta são obrigatórios");
                }
               

                //Verifica se o valor da consulta é Nula ou vazia
                
                if (registro.Valor < 0)
                {
                    msgErro.AppendLine("Valor inválido");
                }
                
                
                if (registro.Diagnostico.Length > 500)
                {
                    msgErro.AppendLine("Campo só pode conter 500 caracteres");
                }



                //Retorna erro quando existir no StringBuilder
                if (msgErro.Length > 0)
                {
                    throw new Exception(msgErro.ToString());
                }



                //Executa o método de inserir registro
                return da.Inserir(registro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza registro na base de dados
        /// </summary>
        /// <param name="registro">Animal</param>
        /// <returns>Animal</returns>
        public Consulta Atualizar(Consulta registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Consulta>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o animal existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Consulta a = Listar().Where(x => x.IdConsulta == registro.IdConsulta).FirstOrDefault();
                if (a == null)
                {
                    msgErro.AppendLine("A consulta não está registrada");
                }

                if (registro.DataHora == DateTime.MinValue)
                {
                    msgErro.AppendLine("Data e hora da consulta são obrigatórios");
                }


                //Verifica se o valor da consulta é Nula ou vazia

                if (registro.Valor < 0)
                {
                    msgErro.AppendLine("Valor inválido");
                }


                if (registro.Diagnostico.Length > 500)
                {
                    msgErro.AppendLine("Campo só pode conter 500 caracteres");
                }



                //Retorna erro quando existir no StringBuilder
                if (msgErro.Length > 0)
                {
                    throw new Exception(msgErro.ToString());
                }
                //Executa o método de atualizar registro
                return da.Atualizar(registro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir registro da tabela
        /// </summary>
        /// <param name="registro">int</param>
        /// <returns>bool</returns>
        public bool Excluir(int id)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Consulta>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Consulta registro = Listar().Where(x => x.IdConsulta == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("A consulta não está na base de dados");
                }

                //Retorna erro quando existir no StringBuilder
                if (msgErro.Length > 0)
                {
                    throw new Exception(msgErro.ToString());
                }

                //Executa o método de atualizar registro
                return da.Excluir(registro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para selecionar todos os registros da tabela
        /// </summary>
        /// <returns>List</returns>
        public List<Consulta> Listar()
        {
            try
            {
                da = new BaseCRUD<Consulta>();

                return da.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    


        
   