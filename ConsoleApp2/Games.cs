//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        public int Id { get; set; }
        public Nullable<int> Team1 { get; set; }
        public Nullable<int> Team2 { get; set; }
    
        public virtual Teams Teams { get; set; }
        public virtual Teams Teams1 { get; set; }
    }
}