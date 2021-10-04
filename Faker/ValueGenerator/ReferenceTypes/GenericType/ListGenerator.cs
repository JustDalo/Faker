using System;
using System.Collections;
using System.Collections.Generic;
using Faker.ValueGenerator.PrimitiveTypes;
using Faker.ValueGenerator.PrimitiveTypes.IntegerTypes;

namespace Faker.ValueGenerator.ReferenceTypes.GenericType
{
    public class ListGenerator : IGenericTypeGenerator
    {
        private static readonly Random Random = new Random();
        protected IDictionary<Type, IPrimitiveTypeGenerator> baseTypesGenerators;

        public Type GenerateType { get; set; }

        public ListGenerator(IDictionary<Type, IPrimitiveTypeGenerator> baseTypesGenerators)
        {
            this.baseTypesGenerators = baseTypesGenerators;
        }

        public object Generate(Type baseType)
        {
            IList result = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(baseType));
            var listLenght = Random.Next(5, 40);
            if (baseTypesGenerators.TryGetValue(baseType, out IPrimitiveTypeGenerator baseTypeGenerator))
            {
                for (int i = 0; i < listLenght; i++)
                {
                    result.Add(baseTypeGenerator.Generate());
                }
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}