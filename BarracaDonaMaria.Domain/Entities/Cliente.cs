namespace BarracaDonaMaria.Domain.Entities;

public class Cliente : IEntity
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Endereco { get; set; }
    public virtual string Telefone { get; set; }
    public virtual string Cpf { get; set; }
    public virtual double Saldo { get; set; }
}
