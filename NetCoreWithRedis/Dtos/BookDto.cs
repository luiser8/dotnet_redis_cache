namespace NetCoreWithRedis.Dtos;

public class BookDto
{
    public int IdBook { get; set; }
    public string? Title { get; set; }
    public string? Editorial { get; set; }
    public int Edition { get; set; }
    public DateTime? CreationAt { get; set; }
    public virtual List<AuthorDto>? Authors { get; set; }
}