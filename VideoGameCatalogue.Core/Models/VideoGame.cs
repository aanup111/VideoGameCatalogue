namespace VideoGameCatalogue.Core.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Decimal used for monetary values to avoid floating-point rounding issues
        public decimal Price { get; set; }
        public double Rating { get; set; }

        // Nullable as description field will be optional
        public string? Description { get; set; }

    }
}
