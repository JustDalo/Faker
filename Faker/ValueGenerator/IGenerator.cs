using System;

namespace Faker.ValueGenerator
{
    public interface IGenerator
    {
        Type GenerateType { get; }
    }
}