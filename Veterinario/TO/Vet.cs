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
    
    public partial class Vet
    {
        public Vet()
        {
            this.Consulta = new HashSet<Consulta>();
        }
    
        public int IdVeterinario { get; set; }
        public string NomeVeterinario { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Whatsapp { get; set; }
        public string CRVM { get; set; }
        public string CelularVeterinario { get; set; }
        public string TelefoneVeterinario { get; set; }
        public string Especialidade { get; set; }
    
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}