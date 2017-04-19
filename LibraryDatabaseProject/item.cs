namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.item")]
    public partial class item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public item()
        {
            ratings = new HashSet<rating>();
            rents_returns = new HashSet<rents_returns>();
        }

        [Key]
        public int item_id { get; set; }

        [Column(TypeName = "char")]
        [StringLength(100)]
        public string Item_title { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string genre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? release_date { get; set; }

        public virtual book book { get; set; }

        public virtual movie movie { get; set; }

        public virtual musicalbum musicalbum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rating> ratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rents_returns> rents_returns { get; set; }
    }
}
