// A record is a compact, immutable reference type — perfect for simple
// data objects like this product catalog entry.
public record Product(int Id, string Name, string Category, decimal Price, bool InStock);

// Used for the LINQ Join demo: each category carries a discount percentage.
public record CategoryDiscount(string Category, decimal DiscountPercent);
