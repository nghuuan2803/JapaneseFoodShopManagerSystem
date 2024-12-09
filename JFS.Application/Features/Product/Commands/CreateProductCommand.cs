using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain.Entities;
using JFS.Shared.DTOs;
using MediatR;

namespace JFS.Application
{
    public class CreateProductCommand : IRequest<Result<ProductDTO>>
    {
        public string Id { get; set; }

        [MinLength(3,ErrorMessage ="Tên không được bỏ trống")]
        public string Name { get; set; }
        public string? CategoryId { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Images { get; set; }
        public bool Discontinued { get; set; }
        public bool IsHot { get; set; }

    }
}
