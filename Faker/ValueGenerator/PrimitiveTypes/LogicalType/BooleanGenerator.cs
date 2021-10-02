using System;

namespace Faker.ValueGenerator.PrimitiveTypes.LogicalType
{
    public class BooleanGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random random = new Random();

        public Type GenerateType { get; set; }

        public object Generate()
        {
            var num = random.Next();
            return num != 0;
        }
        
    }
}