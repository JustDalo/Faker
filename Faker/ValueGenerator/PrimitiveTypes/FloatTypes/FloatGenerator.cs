using System;

namespace Faker.ValueGenerator.PrimitiveTypes.FloatTypes
{
    public class FloatGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();

        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(float);
            return (float) Random.NextDouble();
        }
    }
}