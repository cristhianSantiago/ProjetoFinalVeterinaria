using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinario.DA;
using Veterinario.TO;

namespace Veterinario.BO
{
    class AnimalBO
    {
         //Cria o objeto da BaseCRUD
        BaseCRUD<Animal> da = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">Cliente</param>
        /// <returns>Cliente</returns>
        public Animal Inserir(Animal registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Animal>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.NomeAnimal))
                {
                    msgErro.AppendLine("Nome do animal é obrigatório");
                }
                else if (registro.NomeAnimal.Length > 150)
                {
                    msgErro.AppendLine("Nome só pode conter 150 caracteres");
                }

               
                //Verifica se a Data de nascimento é Nula ou vazia
                //Verifica se a Data de Nascimento é maior que data atual
                if (string.IsNullOrEmpty(registro.DataNascimento.ToString()))
                {
                    msgErro.AppendLine("Data de Nascimento é obrigatório");
                }
                else if (registro.DataNascimento > DateTime.Now)
                {
                    msgErro.AppendLine("Data de Nascimento é maior que a data atual");
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
        public Animal Atualizar(Animal registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Animal>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o Cliente existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Animal a = Listar().Where(x => x.IdAnimal == registro.IdAnimal).FirstOrDefault();
                if (a == null)
                {
                    msgErro.AppendLine("O cliente informado não está na base de dados");
                }

                //Verifica se o Nome do Usuário está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.NomeAnimal))
                {
                    msgErro.AppendLine("Nome é obrigatório");
                }
                else if (registro.NomeAnimal.Length > 150)
                {
                    msgErro.AppendLine("Nome só pode conter 150 caracteres");
                }

                

                //Verifica se a Data de nascimento é Nula ou vazia
                //Verifica se a Data de Nascimento é maior que data atual
                if (string.IsNullOrEmpty(registro.DataNascimento.ToString()))
                {
                    msgErro.AppendLine("Data de Nascimento é obrigatório");
                }
                else if (registro.DataNascimento > DateTime.Now)
                {
                    msgErro.AppendLine("Data de Nascimento é maior que a data atual");
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
                da = new BaseCRUD<Animal>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Cliente registro = Listar().Where(x => x.IdCliente == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("O cliente informado não está na base de dados");
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
        public List<Cliente> Listar() {
            try
            {
                da = new BaseCRUD<Animal>();

                return da.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }

