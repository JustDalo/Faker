using System;

namespace Faker.ValueGenerator.PrimitiveTypes.CharType
{
    public class CharGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        private string AlphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public Type GenerateType { get; set; }

        public CharGenerator()
        {
            GenerateType = typeof(int);
        }

        public object Generate()
        {
            return (char) AlphaChars[Random.Next(AlphaChars.Length)];
        }
    }
}