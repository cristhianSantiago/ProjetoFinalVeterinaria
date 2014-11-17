using Veterinario.TO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinario.DA
{
    internal class BaseCRUD<T> where T : class
    {
        dbVeterinariaEntities conn = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">T</param>
        /// <returns>T</returns>
        internal T Inserir(T registro)
        {
            //Inicia variavel de retorno
            T retorno = null;
            try
            {
                //Abre base de dados
                conn = new dbVeterinariaEntities();
                //Insere o registro via Entity
                retorno = conn.Set<T>().Add(registro);
                //Salva o registro na base de dados
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorno de Erro
                throw new Exception(string.Format("{0} - {1}", ex.Message, ex.InnerException));
            }
            finally
            {
                //Fecha base de dados
                conn.Dispose();
            }

            //Retorna o registro inserido
            return retorno;
        }

        /// <summary>
        /// Atualiza registro na base de dados
        /// </summary>
        /// <param name="registro">T</param>
        /// <returns>T</returns>
        internal T Atualizar(T registro)
        {
            //Inicia a variavel de retorno
            T retorno = null;
            try
            {
                //Abre a base de dados
                conn = new dbVeterinariaEntities();

                //Trava a tabela para fazer a alteração do registro
                conn.Set<T>().AsNoTracking();
                //Anexar a tabela o registro a ser atualizado
                retorno = conn.Set<T>().Attach(registro);
                //Atualizar a entrada do registro
                conn.Entry<T>(registro).State = EntityState.Modified;
                //Salvar na base de dados
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorno de Erro
                throw new Exception(string.Format("{0} - {1}", ex.Message, ex.InnerException));
            }
            finally
            {
                //Fecha base de dados
                conn.Dispose();
            }

            //Retorna o registro inserido
            return retorno;
        }

        /// <summary>
        /// Método para excluir registro da tabela
        /// </summary>
        /// <param name="registro">T</param>
        /// <returns>bool</returns>
        internal bool Excluir(T registro)
        {
            bool retorno = false;
            try
            {
                conn = new dbVeterinariaEntities();

                //Trava a tabela para fazer a exclusão do registro
                conn.Set<T>().AsNoTracking();
                //Anexar a tabela o registro a ser excluido
                conn.Set<T>().Attach(registro);
                //Excluir a entrada do registro
                conn.Entry<T>(registro).State = EntityState.Deleted;
                //Salvar na base de dados
                conn.SaveChanges();

                retorno = true;
            }
            catch (Exception ex)
            {
                //Retorno de Erro
                throw new Exception(string.Format("{0} - {1}", ex.Message, ex.InnerException));
            }
            finally
            {
                //Fecha base de dados
                conn.Dispose();
            }

            return retorno;
        }

        /// <summary>
        /// Método para selecionar todos os registros da tabela
        /// </summary>
        /// <returns>List</returns>
        internal List<T> Listar()
        {
            
            try
            {
                conn = new dbVeterinariaEntities();

                //Retorna a Listagem da tabela
                return conn.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} - {1}", ex.Message, ex.InnerException));
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
