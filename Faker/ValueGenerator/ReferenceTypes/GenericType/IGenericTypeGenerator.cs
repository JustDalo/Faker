using System;

namespace Faker.ValueGenerator.ReferenceTypes.GenericType
{
    public interface IGenericTypeGenerator : IGenerator
    {
        object Generate(Type baseType);
    }
}