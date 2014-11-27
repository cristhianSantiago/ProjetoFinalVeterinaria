using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinario.Biblioteca;
using Veterinario.DA;
using Veterinario.TO;

namespace Veterinario.BO
{
   public class VeterinarioBO
    
       {
        //Cria o objeto da BaseCRUD
       BaseCRUD<Vet> da = null;

        /// <summary>
        /// Método para inserir registro na base de dados
        /// </summary>
        /// <param name="registro">Veterinario</param>
        /// <returns>Veterinario</returns>
       public Vet Inserir(Vet registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Vet>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.NomeVeterinario))
                {
                    msgErro.AppendLine("Nome é obrigatório");
                }
                
                else if (registro.NomeVeterinario.Length > 150)
                {
                    msgErro.AppendLine("Nome só pode conter 150 caracteres");
                }


                //Verifica se o registro está Nulo ou Vazio
                //Verifica se o valor informado é válido
                if (string.IsNullOrEmpty(registro.CPF))
                {
                    msgErro.AppendLine("CPF é obrigatório");
                }
                else if (!Validacao.Cpf(registro.CPF))
                {
                    msgErro.AppendLine("CPF inválido");
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
        /// <param name="registro">Veterinario</param>
        /// <returns>Veterinario</returns>
       public Vet Atualizar(Vet registro)
        {
            try
            {
                //Instância objeto do CRUD
                da = new BaseCRUD<Vet>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o Veterinario existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Vet c = Listar().Where(x => x.IdVeterinario == registro.IdVeterinario).FirstOrDefault();
                if (c == null)
                {
                    msgErro.AppendLine("O Veterinario informado não está na base de dados");
                }

                //Verifica se o Nome do Usuário está Nulo ou Vazio
                //Verifica se a quantidade de caracteres é maior que possível
                if (string.IsNullOrEmpty(registro.NomeVeterinario))
                {
                    msgErro.AppendLine("Nome é obrigatório");
                }
                else if (registro.NomeVeterinario.Length > 150)
                {
                    msgErro.AppendLine("Nome só pode conter 150 caracteres");
                }

                //Verifica se o registro é Nulo ou Vazio
                //Verifica se o CPF informado é válido
                if (string.IsNullOrEmpty(registro.CPF))
                {
                    msgErro.AppendLine("CPF é obrigatório");
                }
                else if (!Validacao.Cpf(registro.CPF))
                {
                    msgErro.AppendLine("CPF inválido");
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
                da = new BaseCRUD<Vet>();

                //Inicia o StringBuilder para gerar o texto com mensagens de erro
                StringBuilder msgErro = new StringBuilder();

                //Verifica se o registro existe na base de dados
                //Utilizando LINQ para recuperar o registro
                Vet registro = Listar().Where(x => x.IdVeterinario == id).FirstOrDefault();
                if (registro == null)
                {
                    msgErro.AppendLine("O Veterinario informado não está na base de dados");
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
        public List<Vet> Listar()
        {
            try
            {
                da = new BaseCRUD<Vet>();

                return da.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

    
