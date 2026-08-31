using System;
using System.Collections.Generic;
using System.Text;
using ApiTests.DTO.DapperTestsDTO;

namespace ApiTests.Interfaces.DapperTestsInterfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductAsync(int id);
    }
}