﻿using System.Collections.Generic;
using System.Threading.Tasks;
using tnine.Application.Shared.Authorization.IPermissionService.Dto;
using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.Authorization.IPermissionService
{
    public interface IPermissionService
    {
        Task<List<GetPermissionForViewDto>> GetAll();
        Task CreateOrEdit(CreateOrEditPermissionDto input);
        Task<GetPermissionForEditOutputDto> GetById(EntityDto<long> input);
        Task Delete(EntityDto<long> input);
        Task<bool> CheckPermission(GetPermissionWithRoleDto input);
        Task<List<NameValueDto>> GetPermissionParent();
    }
}
