﻿using Shop_Models.Dto;
using Shop_Models.Entities;

namespace Shop_API.Repository.IRepository
{
    public interface ICpuRepository
    {
        Task<bool> Create(Cpu obj);
        Task<bool> Update(Cpu obj);
        Task<bool> Delete(Guid id);
        Task<List<Cpu>> GetAllCpus();
        Task<Cpu> GetById(Guid id);
        Task<ResponseDto> CreateReturnDto(Cpu obj);
    }
}
