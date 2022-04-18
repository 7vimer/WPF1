namespace WpfApp5.SQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Водители
    {
        [Key]
        public int ИдентификаторGUID { get; set; }

        [Required]
        [StringLength(50)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(50)]
        public string Имя { get; set; }

        [Required]
        [StringLength(50)]
        public string Отчество { get; set; }

        [Required]
        [StringLength(50)]
        public string Паспорт { get; set; }

        [Required]
        [StringLength(50)]
        public string АдресРегистрации { get; set; }

        [Required]
        [StringLength(50)]
        public string АдресПроживания { get; set; }

        [Required]
        [StringLength(50)]
        public string МестоРаботы { get; set; }

        [Required]
        [StringLength(50)]
        public string Должность { get; set; }

        [Required]
        [StringLength(50)]
        public string МобильныйТелефон { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Фотография { get; set; }

        [StringLength(50)]
        public string Замечания { get; set; }

        public bool? Архив { get; set; }
    }
}
