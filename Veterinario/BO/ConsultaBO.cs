using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinario.DA;
using Veterinario.TO;

namespace Veterinario.BO
{
    class ConsultaBO
    {
        //Cria o objeto da BaseCRUD
        BaseCRUD<Consulta> da = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">Locacao</param>
        /// <returns>Locacao</returns>
        public Consulta Inserir(Consulta registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Consulta>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro da chave estrangeira existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Cliente c = new ClienteBO().Listar().Where(x => x.IdCliente == registro.IdAnimalFK).FirstOrDefault();
                if (c == null)
                {
                    msgErro.AppendLine("O Cliente informado não está na base de dados");
                }

                //Verifica se o registro da chave estrangeira existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Animal a = new AnimalBO().Listar().Where(x => x.IdAnimal == registro.IdAnimalFK).FirstOrDefault();
                if (a == null)
                {
                    msgErro.AppendLine("O Filme informado não está na base de dados");
                }

                //Coloca a data de entrega do filme 5 dias após a data de locação
                registro.DataHora = registro.DataHora;

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
        /// <param name="registro">Locacao</param>
        /// <returns>Locacao</returns>
        public Consulta Atualizar(Consulta registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Consulta>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Consulta t = Listar().Where(x => x.IdConsulta == registro.IdConsulta).FirstOrDefault();
                if (t == null)
                {
                    msgErro.AppendLine("O Locacao informado não está na base de dados");
                }

                //Verifica se o registro da chave estrangeira existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Cliente c = new ClienteBO().Listar().Where(x => x.IdCliente == registro.IdAnimalFK).FirstOrDefault();
                if (c == null)
                {
                    msgErro.AppendLine("O Cliente informado não está na base de dados");
                }

                //Verifica se o registro da chave estrangeira existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Animal f = new AnimalBO().Listar().Where(x => x.IdAnimal == registro.IdAnimalFK).FirstOrDefault();
                if (f == null)
                {
                    msgErro.AppendLine("O Filme informado não está na base de dados");
                }

                //Coloca a data de entrega do filme 5 dias após a data de locação
                registro.DataHora = registro.DataHora.AddDays(5);

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

                //Verifica se o Locacao existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Consulta registro = Listar().Where(x => x.IdConsulta == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("O Locacao informado não está na base de dados");
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
