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
    
    public partial class BASKET
    {
        public int ID_ORDER { get; set; }
        public int ID_GOOD { get; set; }
        public int COUNT { get; set; }
    
        public virtual GOOD GOOD { get; set; }
        public virtual ORDER ORDER { get; set; }
    }
}
