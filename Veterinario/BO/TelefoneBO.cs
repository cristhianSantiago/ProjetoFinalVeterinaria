using RegraNegocio.DA;
using RegraNegocio.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraNegocio.BO
{
    public class TelefoneBO
    {
        //Cria o objeto da BaseCRUD
        BaseCRUD<Telefone> da = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">Telefone</param>
        /// <returns>Telefone</returns>
        public Telefone Inserir(Telefone registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Telefone>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro da chave estrangeira existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Cliente c = new ClienteBO().Listar().Where(x => x.IdCliente == registro.IdClienteFK).FirstOrDefault();
                
                //var l = new ClienteBO().Listar();

                //Cliente c = (from cl in l
                //             where cl.IdCliente == registro.IdClienteFK
                //             select cl).FirstOrDefault();

                if (c == null)
                {
                    msgErro.AppendLine("O Cliente informado não está na base de dados");
                }

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.NumeroTelefone))
                {
                    msgErro.AppendLine("Número de Telefone é obrigatório");
                }
                else if (registro.NumeroTelefone.Length > 20)
                {
                    msgErro.AppendLine("Número de Telefone só pode conter 20 caracteres");
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
        /// <param name="registro">Telefone</param>
        /// <returns>Telefone</returns>
        public Telefone Atualizar(Telefone registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Telefone>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Telefone t = Listar().Where(x => x.IdTelefone == registro.IdTelefone).FirstOrDefault();
                if (t == null)
                {
                    msgErro.AppendLine("O Telefone informado não está na base de dados");
                }

                //Verifica se o registro da chave estrangeira existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Cliente c = new ClienteBO().Listar().Where(x => x.IdCliente == registro.IdClienteFK).FirstOrDefault();
                if (c == null)
                {
                    msgErro.AppendLine("O Cliente informado não está na base de dados");
                }

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.NumeroTelefone))
                {
                    msgErro.AppendLine("Número de Telefone é obrigatório");
                }
                else if (registro.NumeroTelefone.Length > 20)
                {
                    msgErro.AppendLine("Número de Telefone só pode conter 20 caracteres");
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
                da = new BaseCRUD<Telefone>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o Telefone existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Telefone registro = Listar().Where(x => x.IdTelefone == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("O Telefone informado não está na base de dados");
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
        public List<Telefone> Listar()
        {
            try
            {
                da = new BaseCRUD<Telefone>();

                return da.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
