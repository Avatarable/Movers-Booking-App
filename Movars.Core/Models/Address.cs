namespace Movars.Core.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public Address()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
