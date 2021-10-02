using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class UIntegerGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(uint);
            return (uint) Math.Round(Random.NextDouble());
        }

    }
}