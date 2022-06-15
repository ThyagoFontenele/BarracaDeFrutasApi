using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications.ClienteSpecification;

public class ClienteRegistrationValidationService : SpecificationsResponses
{
    private Cliente Cliente { get; set; }

    public ClienteRegistrationValidationService(Cliente cliente) =>
        Cliente = cliente;

    public bool Validate()
    {
        var cpfLengthSpec = new CpfLengthSpecification();
        var nomeLengthSpec = new NameLengthSpecification();
        this.Add(cpfLengthSpec.ErrorMessage, cpfLengthSpec.IsSatisfiedBy(Cliente));
        this.Add(nomeLengthSpec.ErrorMessage, nomeLengthSpec.IsSatisfiedBy(Cliente));

        return cpfLengthSpec.IsSatisfiedBy(Cliente) &&
            nomeLengthSpec.IsSatisfiedBy(Cliente);
    }
}
