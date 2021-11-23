﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }

        //kısıtlamalar
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz!")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu Alanı Boş Geçemezsiniz!")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Meslek { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Telefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Gorsel { get; set; }

        //Bir cari birden fazla SatısHaereketinde olabilir o yüzden ICollection Kullandık
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        
    }
}