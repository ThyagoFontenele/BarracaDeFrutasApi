using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications.PedidoSpecification;
 
public class FinalizadoFalseSpecification : ISpecification<Pedido>
{
    public string ErrorMessage { get; } = "Erro não é possível criar um pedido já finalizado";

    public bool IsSatisfiedBy(Pedido pedido) =>
        pedido.Finalizado == false;
}
