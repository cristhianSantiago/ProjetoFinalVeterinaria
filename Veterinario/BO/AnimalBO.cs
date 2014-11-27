using Veterinario.DA;
using Veterinario.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinario.BO
{
    public class AnimalBO
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


                //Verifica se a Data de nascimento é Nula ou vazia
                //Verifica se a Data de Nascimento é maior que data atual
                if (string.IsNullOrEmpty(registro.NascimentoAnimal.ToString()))
                {
                    msgErro.AppendLine("Data de Nascimento é obrigatório");
                }
                else if (registro.NascimentoAnimal > DateTime.Now)
                {
                    msgErro.AppendLine("Data de Nascimento é maior que a data atual");
                }

                //Retorna erro quando existir no StringBuilder
                if (msgErro.Length > 0)
                {
                    throw new Exception(msgErro.ToString());
                }

                if (string.IsNullOrEmpty(registro.Alergico))
                {
                    msgErro.AppendLine("Alergico é obrigatório");
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

                //Verifica se o animal existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Animal a = Listar().Where(x => x.IdAnimal == registro.IdAnimal).FirstOrDefault();
                if (a == null)
                {
                    msgErro.AppendLine("O Animal informado não está na base de dados");
                }

                //Verifica se o registro está Nulo ou Vazio
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
                if (registro.NascimentoAnimal > DateTime.Now)
                {
                    msgErro.AppendLine("Data de Nascimento é maior que a data atual");
                }

                if (string.IsNullOrEmpty(registro.Alergico))
                {
                    msgErro.AppendLine("Alergico é obrigatório");
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
                Animal registro = Listar().Where(x => x.IdAnimal == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("O Animal informado não está na base de dados");
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
        public List<Animal> Listar() {
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
    

