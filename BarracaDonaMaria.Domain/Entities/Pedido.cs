namespace BarracaDonaMaria.Domain.Entities;

public class Pedido : IEntity
{
    public virtual int Id { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual DateTime? Data { get; set; }
    public virtual IList<ItemPedido> Items { get; set; }
    public virtual double Total { get; set; }
    public virtual bool Finalizado { get; set; }
}
