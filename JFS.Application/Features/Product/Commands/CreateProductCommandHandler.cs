using JFS.Domain.Entities;
using JFS.Shared.DTOs;
using MediatR;
using AutoMapper;
using JFS.Domain;

namespace JFS.Application
{
    public class CreateProductCommandHandler(IMapper _mapper)
        : IRequestHandler<CreateProductCommand, Result<ProductDTO>>
    {
        public async Task<Result<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //handle logic here...
            var product = _mapper.Map<Product>(request);
            //var key = await _repository.AddAsync(product);
            var dto = _mapper.Map<ProductDTO>(product);
            return Result<ProductDTO>.Success(dto);
        }
    }
}
