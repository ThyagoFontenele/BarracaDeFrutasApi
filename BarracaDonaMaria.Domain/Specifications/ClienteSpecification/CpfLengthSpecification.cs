﻿using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Specifications.ClienteSpecification;

public class CpfLengthSpecification : ISpecification<Cliente>
{
    public string ErrorMessage { get; } = "CPF inválido!";

    public bool IsSatisfiedBy(Cliente cliente) =>
        cliente.Cpf.Count() == 11;
}

