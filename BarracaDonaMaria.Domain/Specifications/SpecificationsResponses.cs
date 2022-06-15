using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications;

public abstract class SpecificationsResponses
{
    private readonly IDictionary<string, bool> Validations = new Dictionary<string, bool>();

    public ICollection<string> InvalidResponses() =>
        Validations.Keys;

    public void Add(string message, bool spec)
    {
        if (!spec)
        {
            Validations.Add(message, spec);
        }
    }
}

