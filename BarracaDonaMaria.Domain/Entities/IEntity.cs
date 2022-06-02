namespace BarracaDonaMaria.Domain.Entities;

public interface IEntity
{
    int Id { get; set; }
}

public interface IEntity<T>
{
    T Id { get; set; }
}
