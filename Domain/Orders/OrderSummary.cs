namespace Domain.Orders
{
    // sınıfta herhangi bir davranışa sahip olmayacağımız için record olarak tanımlamak daha mantıklı
    public record OrderSummary(Guid OrderId, Guid CustomerId, decimal TotalPrice);
}
