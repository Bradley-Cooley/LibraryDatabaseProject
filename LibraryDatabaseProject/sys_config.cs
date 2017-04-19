namespace LibraryDatabaseProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys.sys_config")]
    public partial class sys_config
    {
        [Key]
        public string variable { get; set; }

        [StringLength(128)]
        public string value { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime set_time { get; set; }

        [StringLength(128)]
        public string set_by { get; set; }
    }
}
