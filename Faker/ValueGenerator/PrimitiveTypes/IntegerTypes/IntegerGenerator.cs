using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class IntegerGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();

        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(int);
            return Random.Next();
        }
    }
}