using System;

namespace Data.Base.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { set; get; }

        int CreatedBy { set; get; }

        int? Status { get; set; }

        DateTime? UpdatedDate { set; get; }

        int? UpdatedBy { get; set; }
    }
}