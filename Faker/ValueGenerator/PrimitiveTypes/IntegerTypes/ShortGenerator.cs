using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class ShortGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(short);
            return (short) Random.Next();
        }
    }
}