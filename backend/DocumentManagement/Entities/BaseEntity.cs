namespace DocumentManagement.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
