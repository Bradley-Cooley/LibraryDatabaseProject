namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.publisher")]
    public partial class publisher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public publisher()
        {
            book_publishedby = new HashSet<book_publishedby>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int publisher_id { get; set; }

        [Column(TypeName = "char")]
        [StringLength(100)]
        public string address { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string publisher_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book_publishedby> book_publishedby { get; set; }
    }
}
