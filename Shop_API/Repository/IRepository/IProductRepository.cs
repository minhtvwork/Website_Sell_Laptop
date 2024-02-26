﻿using Shop_Models.Dto;
using Shop_Models.Entities;
namespace Shop_API.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<bool> Create(Product obj);
        Task<bool> Update(Product obj);
        Task<bool> Delete(Guid idobj);

        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<IEnumerable<ProductDto>> GetProductDtos(string? search, double? from, double? to, string? sortBy, int page = 1);
    }
}
