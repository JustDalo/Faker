using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class ULongGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(ulong);
            return (ulong) Math.Round(Random.NextDouble());
        }

    }
}