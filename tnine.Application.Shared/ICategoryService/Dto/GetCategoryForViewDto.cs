﻿using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.ICategoryService.Dto
{
    public class GetCategoryForViewDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}