namespace DocumentManagement.Entities
{
    public class DocumentLog : BaseEntity
    {
        public DateTime Timestamp { get; set; }
        public string Note { get; set; }
    }
}
