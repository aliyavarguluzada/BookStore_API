using BookStore_API.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_API.Domain.Entities
{
    public class File : BaseEntity
    {
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
