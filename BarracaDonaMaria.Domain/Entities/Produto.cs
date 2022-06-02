namespace BarracaDonaMaria.Domain.Entities;

public class Produto : IEntity
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Tipo { get; set; }
    public virtual int Unidades { get; set; }
    public virtual double Preco { get; set; }
    public virtual string ImgUrl { get; set; }
}
