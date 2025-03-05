using System.ComponentModel.DataAnnotations;
using CleanArch.Domain.Abstractions;

namespace CleanArch.Domain.Entities;

public sealed class Customer : Entity
{
    [MaxLength(50)] public required string Name { get; set; }
    [MaxLength(50)] public string? TaxDepartment { get; set; }
    public string? TaxNumber { get; set; }
    [MaxLength(50)] public required string City { get; set; }
    [MaxLength(50)] public required string Town { get; set; }
    [MaxLength(50)] public required string FullAddress { get; set; }
}