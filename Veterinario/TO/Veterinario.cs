//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veterinario.TO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Veterinario
    {
        public Veterinario()
        {
            this.Consulta = new HashSet<Consulta>();
            this.TelefoneVeterianrio = new HashSet<TelefoneVeterianrio>();
        }
    
        public int IdVeterinario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Whatsapp { get; set; }
        public string CRVM { get; set; }
        public string Especialidade { get; set; }
    
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<TelefoneVeterianrio> TelefoneVeterianrio { get; set; }
    }
}
