using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications.PedidoSpecification;

public class PedidoRegistrationValidationService : SpecificationsResponses
{
    private Pedido Pedido { get; set; }

    public PedidoRegistrationValidationService(Pedido pedido) =>
        Pedido = pedido;

    public bool Validate()
    {
        var finalizadoSpec = new FinalizadoFalseSpecification();
        this.Add(finalizadoSpec.ErrorMessage, finalizadoSpec.IsSatisfiedBy(Pedido));

        return finalizadoSpec.IsSatisfiedBy(Pedido);
    }
}