//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Europa.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        public Produto()
        {
            this.Marca = new HashSet<Marca>();
        }
    
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }
        public bool Status { get; set; }
        public string Logo { get; set; }
        public System.DateTime DataCad { get; set; }
        public System.DateTime DataUltimaAtualizacao { get; set; }
    
        public virtual ICollection<Marca> Marca { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
