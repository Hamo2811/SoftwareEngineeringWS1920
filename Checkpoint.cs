//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NeukonstChecklistLibDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Checkpoint
    {
        public int Id { get; set; }
        public string Beschreibung { get; set; }
        public int AuftragsknotenId { get; set; }
        public bool Erledigt { get; set; }
        public int Auftragsnummer { get; set; }
        public string Baureihe { get; set; }
    
        public virtual Auftragsknoten Auftragsknoten { get; set; }
    }
}
