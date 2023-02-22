namespace MyWebNorthwind.Models
{
    public abstract class AbstractBaseEntity
    {
        public string Creator { get; set; }

        public DateTime CreatingDate { get; set; }

        public string Modified { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsRemoved { get; set; }

    }
}
