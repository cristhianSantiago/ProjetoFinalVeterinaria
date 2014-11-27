using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veterinario.BO;
using Veterinario.TO;

namespace Interface
{
    public partial class ClientesAlt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              try
              {
                  string g_md = Request["g_md"];

                  if (!IsPostBack)
                  {
                      switch (g_md)
                      {
                          case "IN":
                              ltrTitulo.Text = "Inclusão de Cliente";
                              btnSalvar.Text = "Inserir";
                              break;
                          case "UP":
                              ltrTitulo.Text = "Atualização de Cliente";

                              CarregarRegistro();
                            
                              break;
                          case "EX":
                            ltrTitulo.Text = "Exclusão de Cliente";
                            pnlForm.Visible = false;
                            pnlExcluir.Visible = true;
                            CarregarRegistro();

                              break;
                          default:
                              ltrTitulo.Text = "Modo de manutenção desconhecido";
                              divForm.Visible = false;  
                              break;
                      }
                  }
              }
              catch (Exception ex)
              {
                  throw new Exception(ex.Message);
              }
          }

          private void CarregarRegistro()
          {
              try
              {
                  int id = int.Parse(Request["id"]);

                  ClienteBO regraBO = new ClienteBO();

                  Cliente registro = regraBO.Listar().Where(x => x.IdCliente == id).FirstOrDefault();

                  if (registro == null)
                  {
                      throw new Exception("O cliente informado não foi encontrado");
                  }

                  nome.Text = registro.Nome;
                  cpf.Text = registro.CPF;
                  rg.Text = registro.RG;
                  dataNascimento.Text = string.Format("{0:dd/MM/yyyy}", registro.DataNascimento);
                  whatsapp.Text = registro.Whatsapp;
                  Celular.Text = registro.TelefoneCelular;

               
              }
              catch (Exception ex)
              {
                  throw new Exception(ex.Message);
              }
          }

          protected void btnSalvar_Click(object sender, EventArgs e)
          {
              try
              {
                  string msg = string.Empty;

                  if (string.IsNullOrEmpty(hdfID.Value))
                  {
                      ClienteBO regraBO = new ClienteBO();
                      Cliente registro = new Cliente();

                      registro.Nome = nome.Text.Trim();
                      registro.CPF = cpf.Text.Trim();
                      registro.RG = rg.Text.Trim();
                      registro.DataNascimento = DateTime.Parse(dataNascimento.Text.Trim());
                      registro.Whatsapp = whatsapp.Text.Trim();
                      registro.TelefoneCelular = Celular.Text.Trim();

                      regraBO.Inserir(registro);

                      msg = "Cliente inserido com sucesso";
                  }
                  else
                  {
                      ClienteBO regraBO = new ClienteBO();
                      Cliente registro = new Cliente();

                      registro.Nome = nome.Text.Trim();
                      registro.CPF = cpf.Text.Trim();
                      registro.RG = rg.Text.Trim();
                      registro.DataNascimento = DateTime.Parse(dataNascimento.Text.Trim());
                      registro.Whatsapp = whatsapp.Text.Trim();
                      registro.TelefoneCelular = Celular.Text.Trim();

                      Cliente clienteNEW = regraBO.Atualizar(registro);

                      msg = "Cliente alterado com sucesso";
                  }

                  Response.Redirect("Clientes.aspx?g_msg=" + msg);
              }
              catch (Exception ex)
              {
                  throw new Exception(ex.Message);
              }
          }

          protected void btnSim_Click(object sender, EventArgs e)
          {
              try
              {
                  int id = int.Parse(Request["id"]);
                  ClienteBO regraBO = new ClienteBO();
                
                  if (!regraBO.Excluir(id))
                  {
                      throw new Exception("Não foi possível excluir o registro solicitado");
                  }
                  Response.Redirect("Listar.aspx?g_msg=Cliente excluído com sucesso");
              }
              catch (Exception ex)
              {
                  throw new Exception(ex.Message);
              }
          }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
        
        }

        }
    }
    
