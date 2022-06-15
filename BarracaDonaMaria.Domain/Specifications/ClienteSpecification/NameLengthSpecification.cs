using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications.ClienteSpecification;

public class NameLengthSpecification : ISpecification<Cliente>
{
    public string ErrorMessage { get; } = "Nome pequeno demais.";

    public bool IsSatisfiedBy(Cliente cliente) =>
        cliente.Nome.Count() >= 10;
}

