//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientsInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientsInfo()
        {
            this.Users = new HashSet<Users>();
        }
    
        public int ID { get; set; }
        public System.DateTime Entry { get; set; }
        public Nullable<System.DateTime> Departure { get; set; }
        public int RoomID { get; set; }
    
        public virtual Rooms Rooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
