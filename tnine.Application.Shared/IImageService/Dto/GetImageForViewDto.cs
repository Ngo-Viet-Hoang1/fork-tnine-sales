﻿using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.IImageService
{
    public class GetImageForViewDto : EntityDto<long>
    {
        public string ImgUrl { get; set; }
    }
}
