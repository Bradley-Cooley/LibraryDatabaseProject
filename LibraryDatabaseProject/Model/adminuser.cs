namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.adminuser")]
    public partial class adminuser
    {
        [Column(TypeName = "char")]
        [StringLength(50)]
        public string admin_firstName { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string admin_lastName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int admin_id { get; set; }
    }
}
