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
    
    public partial class Technic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Technic()
        {
            this.Repairs = new HashSet<Repair>();
        }
    
        public int TechnicId { get; set; }
        public string TechnicName { get; set; }
        public int InventoryNumber { get; set; }
        public string Model { get; set; }
        public int YearOfIssue { get; set; }
        public int DivisionId { get; set; }
    
        public virtual Division Division { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
