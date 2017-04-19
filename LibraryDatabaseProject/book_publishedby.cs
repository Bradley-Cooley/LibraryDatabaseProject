namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.book_publishedby")]
    public partial class book_publishedby
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        public int? publisher_id { get; set; }

        public virtual book book { get; set; }

        public virtual publisher publisher { get; set; }
    }
}
