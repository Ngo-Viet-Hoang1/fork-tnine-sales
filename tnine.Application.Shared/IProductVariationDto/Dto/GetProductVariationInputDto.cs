﻿using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.IProductVariationDto.Dto
{
    public class GetProductVariationInputDto : PagedAndSortedResultRequestDto
    {
        public long ProductId { get; set; }
    }
}
