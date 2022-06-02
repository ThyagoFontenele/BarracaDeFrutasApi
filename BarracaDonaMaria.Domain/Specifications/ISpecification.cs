using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications;

public interface ISpecification<T> where T : IEntity
{
    bool IsSatisfiedBy(T entity);
    string ErrorMessage { get; }
}

