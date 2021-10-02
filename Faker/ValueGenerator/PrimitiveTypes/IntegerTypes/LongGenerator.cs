using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class LongGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
            
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(long);
            return (long) Math.Round(Random.NextDouble());
        }

    }
}