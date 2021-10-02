using System;

namespace Faker.ValueGenerator.PrimitiveTypes.FloatTypes
{
    public class DoubleGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();

        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(double);
            return Random.NextDouble();
        }
    }
}