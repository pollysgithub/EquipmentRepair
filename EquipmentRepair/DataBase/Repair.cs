//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquipmentRepair.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Repair
    {
        public int RepairId { get; set; }
        public System.DateTime Date { get; set; }
        public int TechnicId { get; set; }
        public int IdEmployeeWhoStartedTheRepair { get; set; }
        public int IdParePart { get; set; }
        public int IdEmployeeWhoAcceptedTheRepair { get; set; }
        public int IdEmployeePerformingTheRepair { get; set; }
        public string TermOfRepair { get; set; }
        public string TypeOfRepair { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
        public virtual ParePart ParePart { get; set; }
        public virtual Technic Technic { get; set; }
    }
}
