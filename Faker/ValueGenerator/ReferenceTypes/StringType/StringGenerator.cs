using System;
using System.Linq;
using Faker.ValueGenerator.PrimitiveTypes;

namespace Faker.ValueGenerator.ReferenceTypes.StringType
{
    public class StringGenerator : IPrimitiveTypeGenerator
    {
        private static readonly Random Random = new Random();
        private const string AlphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public Type GenerateType { get; set; }
        public object Generate()
        {
            return new string(Enumerable.Repeat(AlphaChars, Random.Next(0, 100))
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}