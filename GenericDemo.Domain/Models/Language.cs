namespace GenericDemo.Domain.Models
{
    using System.Collections.Generic;

    public class Language : IEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
