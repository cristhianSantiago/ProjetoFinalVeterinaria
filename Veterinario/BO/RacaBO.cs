using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinario.DA;
using Veterinario.TO;

namespace Veterinario.BO
{
   public class RacaBO
        
    {
       
        //Cria o objeto da BaseCRUD
        BaseCRUD<Raca> da = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">Raca</param>
        /// <returns>Raca</returns>
        public Raca Inserir(Raca registro)
        {
            
            
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Raca>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.RacaAnimal))
                {
                    msgErro.AppendLine("Informe a raça do animal");
                }
                else if (registro.RacaAnimal.Length > 100)
                {
                    msgErro.AppendLine("O nome da raça do animal só pode conter até 100 caracteres");
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
        /// <param name="registro">Raca</param>
        /// <returns>Raca</returns>
        public Raca Atualizar(Raca registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Raca>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o animal existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Raca a = Listar().Where(x => x.IdRaca == registro.IdRaca).FirstOrDefault();
                if (a == null)
                {
                    msgErro.AppendLine("A raça do animal informado não está na base de dados");
                }

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.RacaAnimal))
                {
                    msgErro.AppendLine("Raça do animal é obrigatório");
                }
                else if (registro.RacaAnimal.Length > 100)
                {
                    msgErro.AppendLine("Raça do animal só pode conter até 100 caracteres");
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
                da = new BaseCRUD<Raca>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Raca registro = Listar().Where(x => x.IdRaca == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("A raça do animal informado não está na base de dados");
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
        public List<Raca> Listar() {
            try
            {
                da = new BaseCRUD<Raca>();

                return da.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    

   

