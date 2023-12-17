using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDtoForInsertion
    {
        public string? ProductName { get; init; } = string.Empty;
        [Required(ErrorMessage = "Price is Required.")]
        public decimal Price { get; init; }
        public string? Summary { get; init; } = string.Empty;
        public string? ImageUrl { get; set; }


        public int? CategoryId { get; init; }
    }
}
