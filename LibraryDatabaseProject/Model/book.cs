namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.book")]
    public partial class book
    {
        [Column(TypeName = "char")]
        [StringLength(50)]
        public string author { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        public virtual item item { get; set; }
        //public virtual book_publishedby pub { get; set; }
    }
}
