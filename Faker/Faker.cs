using System;
using System.Collections.Generic;
using System.Dynamic;
using Faker.ValueGenerator;
using Faker.ValueGenerator.PrimitiveTypes;
using Faker.ValueGenerator.PrimitiveTypes.LogicalType;

namespace Faker
{
    public class Faker
    {
        private Dictionary<Type, IPrimitiveTypeGenerator> _primitiveTypeGenerators;
        
        public Faker()
        {
            _primitiveTypeGenerators = new Dictionary<Type, IPrimitiveTypeGenerator>()
            {
                {typeof(Boolean), new BooleanGenerator()},
                
            };
        }
        
        public T Create<T>()
        {
            var type = typeof(T);
            return (T) Create(type);
        }

        private object Create(Type objectType)
        {
            object generatedType = new object();
            if (_primitiveTypeGenerators.TryGetValue(objectType, out IPrimitiveTypeGenerator primitiveTypeGenerator))
            {
                generatedType = primitiveTypeGenerator.Generate();
            }
            else
            {
                generatedType = null;
            }
            

            return generatedType;
        }
    }
}