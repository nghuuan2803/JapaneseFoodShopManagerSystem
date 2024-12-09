using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Domain.Entities
{
    public class ContentPage : BaseEntity<string>
    {
        public string Title { get; set; }
        public string? Slug { get; set; }
        public required string Content { get; set; }
        public string? Summary { get; set; }
        public string? Thumbnail { get; set; }
        public string? PageCategory { get; set; }
        public ICollection<string>? Tags { get; set; }
        public DateTimeOffset? PublishedDate { get; set; }
        public string AuthorId { get; set; }
        public int Status { get; set; }

        public override void NewKey()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
