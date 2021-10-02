using System;

namespace Faker.ValueGenerator.PrimitiveTypes.IntegerTypes
{
    public class IntegerGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random R = new Random();

        public Type GenerateType { get; set; }

        public object Generate()
        {
            var num = (int) Math.Round(R.NextDouble());
            return num;
        }
    }
}