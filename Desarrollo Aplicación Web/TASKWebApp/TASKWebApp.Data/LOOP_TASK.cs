//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TASKWebApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOOP_TASK
    {
        public LOOP_TASK()
        {
            this.LOOP_TASK_SCHEDULE = new HashSet<LOOP_TASK_SCHEDULE>();
        }
    
        public decimal ID { get; set; }
        public decimal ID_TASK_ASSIGNMENT { get; set; }
        public System.DateTime TIME { get; set; }
        public string ISACTIVE { get; set; }
    
        public virtual TASK_ASSIGNMENT TASK_ASSIGNMENT { get; set; }
        public virtual ICollection<LOOP_TASK_SCHEDULE> LOOP_TASK_SCHEDULE { get; set; }
    }
}
