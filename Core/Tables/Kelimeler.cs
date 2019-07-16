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
    [Table("Kelimeler")]
    public class Kelimeler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kelime"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Kelime { get; set; }

        [DisplayName("Kelime Anlamı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KelimeAnlami { get; set; }

        //[DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        //public string KullaniciAdi { get; set; }
        [ForeignKey("Kullanicilar")]
        public int KullanicilarId { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }

        public bool isOKey { get; set; }
    }
}
