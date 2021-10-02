using System;

namespace Faker.ValueGenerator.PrimitiveTypes.FloatTypes
{
    public class DecimalGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();

        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(decimal);
            return (decimal) Random.NextDouble();
        }
    }
}