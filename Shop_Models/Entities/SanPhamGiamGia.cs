﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Models.Entities
{
    [Table("SanPhamGiamGia")]
    public class SanPhamGiamGia
    {
        [Key]
        public Guid Id { get; set; }

        public double DonGia { get; set; }
        public double SoTienConLai { get; set; }
        public int TrangThai { get; set; }
        public Guid ProductDetailId { get; set; }
        public Guid GiamGiaId { get; set; }
        public virtual GiamGia? GiamGia { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
    }
}
