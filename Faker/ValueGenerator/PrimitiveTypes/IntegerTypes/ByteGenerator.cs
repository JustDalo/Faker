using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class ByteGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(byte);
            return (byte) Random.Next();
        }
    }
}