﻿using System.Threading.Tasks;
using tnine.Application.Shared.IProductService.Dto;
using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.IProductService
{
    public interface IProductService
    {
        Task<PagedResultDto<GetProductForViewDto>> GetAll();
        Task<GetProductForEditDto> GetProductForEdit(long Id);
        Task Delete(long Id);
        Task<long> CreateOrEdit(CreateOrEditProductDto input);
        Task<PagedResultDto<GetProductForViewDto>> GetProductByCategoryId(long CateGoryId);
    }
}
