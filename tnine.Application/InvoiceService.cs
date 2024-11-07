﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tnine.Application.Shared.IInvoiceService;
using tnine.Application.Shared.IInvoiceService.Dto;
using tnine.Core;
using tnine.Core.Shared.Infrastructure;
using tnine.Core.Shared.Repositories;

namespace tnine.Application
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetInvoiceForViewDto>> GetAll()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            var customers = await _customerRepository.GetAllAsync();

            return (from invoice in invoices
                    join customer in customers on invoice.CustomerId equals customer.Id
                    select new GetInvoiceForViewDto
                    {
                        Id = invoice.Id,
                        CreationTime = (DateTime)invoice.CreationTime,
                        CustomerName = customer.FullName,
                        CustomerTelephone = customer.PhoneNumber,
                        Total = invoice.Total
                    }).ToList();
        }

        public async Task CreateOrEdit(CreateOrEditInvoiceDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Edit(input);
            }
        }

        private async Task Create(CreateOrEditInvoiceDto input)
        {
            input.CreationTime = DateTime.Now;
            var invoice = _mapper.Map<Invoice>(input);
            await _invoiceRepository.InsertAsync(invoice);
        }

        private async Task Edit(CreateOrEditInvoiceDto input)
        {
            var invoice = await _invoiceRepository.GetSingleByIdAsync(input.Id.Value);
            _mapper.Map(input, invoice);
            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task<GetInvoiceForEditOutputDto> GetById(long id)
        {
            var invoice = await _invoiceRepository.GetSingleByIdAsync(id);

            return new GetInvoiceForEditOutputDto
            {
                Invoice = _mapper.Map<CreateOrEditInvoiceDto>(invoice)
            };
        }

        public async Task Delete(long id)
        {
            await _invoiceRepository.DeleteAsync(id);
        }
    }
}