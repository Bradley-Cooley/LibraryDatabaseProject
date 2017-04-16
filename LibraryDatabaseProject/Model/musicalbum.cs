namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.musicalbum")]
    public partial class musicalbum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string artist { get; set; }

        public int? num_of_tracks { get; set; }

        public virtual item item { get; set; }
    }
}
