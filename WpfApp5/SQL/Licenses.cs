namespace WpfApp5.SQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Licenses
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? licenseData { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expireDate { get; set; }

        [StringLength(50)]
        public string categories { get; set; }

        [StringLength(5)]
        public string licenseSeries { get; set; }

        [StringLength(6)]
        public string licenseNumber { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
