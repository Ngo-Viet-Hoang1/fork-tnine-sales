﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tnine.Core.Shared.Dtos;

namespace tnine.Application.Shared.IPaymentSatusService.Dto
{
    public class GetPaymentStatusInputDto : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
    }
}
