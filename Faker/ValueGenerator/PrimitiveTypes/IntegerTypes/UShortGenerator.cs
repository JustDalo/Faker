using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class UShortGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        
        public Type GenerateType { get; set; }

        public object Generate()
        {
            GenerateType = typeof(ushort);
            return (ushort) Random.Next();
        }
        
    }
}