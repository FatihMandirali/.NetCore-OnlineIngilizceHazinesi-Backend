using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tables
{
    [Table("Kullanicilar")]
    public class Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KullaniciAdi { get; set; }

        public bool isOKey { get; set; } = true;
    }
}
