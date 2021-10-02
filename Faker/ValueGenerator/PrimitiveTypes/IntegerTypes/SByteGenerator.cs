using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class SByteGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(sbyte);
            return (sbyte) Random.Next();
        }

    }
}