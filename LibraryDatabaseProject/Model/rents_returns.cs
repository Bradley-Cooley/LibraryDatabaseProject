namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.rents_returns")]
    public partial class rents_returns
    {
        public int? rental_length { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime rental_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? return_date { get; set; }

        public bool? returned_bool { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        public virtual item item { get; set; }

        public virtual user user { get; set; }
    }
}
