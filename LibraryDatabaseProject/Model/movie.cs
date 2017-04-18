namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.movie")]
    public partial class movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        public int? duration { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string director { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string mpaa_rating { get; set; }

        public virtual item item { get; set; }
    }
}
