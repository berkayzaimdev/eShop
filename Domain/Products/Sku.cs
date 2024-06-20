namespace Domain.Products
{
    // stock keeping unit (stok numarası)
    public record Sku
    {
        private const int DefaultLength = 15;
        private Sku(string value) => Value = value; // factory metodu yazmak için private ctor kullanmak zorundayız

        public string Value { get; init; }

        // factory metod
        public static Sku? Create(string value)
        {
            if(string.IsNullOrEmpty(value)) return null;

            if(value.Length != DefaultLength) return null;
            
            return new Sku(value);
        }
    }
}
