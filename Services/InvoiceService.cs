using DataAccess.Repositories;
using Dto.Request;
using Dto.Response;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public InvoiceService(IInvoiceRepository repository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        public async Task<InvoiceResponseDto> GetAsync(int id)
        {
            var invoice = await _repository.GetAsync(id);
            if (invoice == null)
                return null;

            return TransformToResponseDto(invoice);
        }

        public async Task<InvoiceResponseDto> CreateAsync(InvoiceRequestDto invoice)
        {
            ClientRequestDto clientRequest = invoice.ClientRequest;
            Client client = await _clientRepository.FindByDNI(clientRequest.DNI);

            if(client == null)
            {
                client = new ()
                {
                    DNI = clientRequest.DNI,
                    Name = clientRequest.Name,
                };
            }
            else
            {
                client.Name = clientRequest.Name;
            }

            Invoice newInvoice = new ()
            {
                Client = client,
                Number = invoice.Number,
                InvoiceDate = invoice.InvoiceDate,
            };
            double subTotal = 0;
            foreach (InvoiceDetailRequestDto detail in invoice.Details)
            {
                Product product = await _productRepository.GetAsync(detail.ProductId);
                if(product == null)
                    throw new Exception("Product no exist Id: " + detail.ProductId);
                InvoiceDetail newDetail = new()
                {
                    ProductId = detail.ProductId,
                    Product = product,
                    ProductName = product.Name,
                    SubProductName = product.SubProduct,
                    Invoice = newInvoice,
                    UnitPrice = product.UnitPrice,
                    Amount = detail.Amount,
                    SubTotal = Math.Round(detail.Amount * product.UnitPrice, 2)

                };

                subTotal += newDetail.SubTotal;
                newInvoice.Details.Add(newDetail);
            }

            double iva = subTotal * 0.12;
            double total = subTotal + iva;

            newInvoice.SubTotal = Math.Round(subTotal, 2);
            newInvoice.IVA = Math.Round(iva, 2);
            newInvoice.Total = Math.Round(total,2);

            await _repository.CreateAsync(newInvoice);

            return TransformToResponseDto(newInvoice);
        }

        public async Task<ICollection<InvoiceResponseDto>> GetAll()
        {
            ICollection <Invoice> invoices = await _repository.GetAll();
            return  invoices.Select(i => TransformToResponseDto(i)).ToList();
        }

        public async Task<ICollection<InvoiceResponseDto>> FindByNumberAsync(string number)
        {
            ICollection<Invoice> invoices = await _repository.FindByNumberAsync(number);

            return invoices.Select(i => TransformToResponseDto(i)).ToList();
        }

        private static InvoiceResponseDto TransformToResponseDto(Invoice invoice)
        {
            InvoiceResponseDto invoiceResponse = new()
            {
                Id = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                Number = invoice.Number,
                SubTotal = invoice.SubTotal,
                IVA = invoice.IVA,
                Total = invoice.Total

            };

            Client client = invoice.Client;

            ClientResponseDto clientResponseDto = new()
            {
                Id = client.Id,
                Name = client.Name,
                DNI = client.DNI,
            };

            invoiceResponse.ClientResponseDto = clientResponseDto;

            foreach(InvoiceDetail detailResponse in invoice.Details)
            {
                invoiceResponse.Details.Add(new InvoiceDetailResponseDto
                {
                    ProductId = detailResponse.ProductId,
                    ProductName = detailResponse.ProductName,
                    SubProductName = detailResponse.SubProductName,
                    Amount = detailResponse.Amount,
                    UnitPrice = detailResponse.UnitPrice,
                    SubTotal =  detailResponse.SubTotal
                });
            }

            return invoiceResponse;
        }
    }
}
