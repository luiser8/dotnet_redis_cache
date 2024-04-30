namespace NetCoreWithRedis.Dtos;

public class BusyBookDto
{
    public int IdBusyBook { get; set; }
    public DateTime? CreationAt { get; set; }
    public virtual ICollection<BookDto>? Book { get; set; }
}