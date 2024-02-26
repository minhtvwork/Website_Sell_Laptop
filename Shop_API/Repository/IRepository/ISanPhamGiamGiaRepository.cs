﻿using Shop_Models.Dto;
using Shop_Models.Entities;

namespace Shop_API.Repository.IRepository
{
    public interface ISanPhamGiamGiaRepository
    {
        Task<ResponseDto> Create(SanPhamGiamGia obj);
        Task<bool> Update(SanPhamGiamGia obj);
        Task<bool> Delete(Guid id);
        Task<List<SanPhamGiamGia>> GetAllSanPhamGiamGias();
        Task<SanPhamGiamGia> GetById(Guid guid);

    }
}
