using System.ComponentModel.DataAnnotations.Schema;

namespace Repository
{
    public abstract class BaseEntity : IObjectState
    {
        [NotMapped]
        public ObjectState State { get; set; }
    }

    public enum ObjectState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
