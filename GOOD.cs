//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pr4
{
    using System;
    using System.Collections.Generic;
    
    public partial class GOOD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GOOD()
        {
            this.BASKET = new HashSet<BASKET>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public int CATEGORY { get; set; }
        public int PRICE { get; set; }
    
        public virtual CATEGORY CATEGORY1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BASKET> BASKET { get; set; }
    }
}
