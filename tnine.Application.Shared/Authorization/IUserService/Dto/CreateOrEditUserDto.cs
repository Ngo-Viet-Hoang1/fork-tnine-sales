﻿using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.Authorization.IUserService.Dto
{
    public class CreateOrEditUserDto : EntityDto<long>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
