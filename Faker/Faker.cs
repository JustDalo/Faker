using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Faker.ValueGenerator;
using Faker.ValueGenerator.PrimitiveTypes;
using Faker.ValueGenerator.PrimitiveTypes.LogicalType;

namespace Faker
{
    public class Faker
    {
        private Dictionary<Type, IPrimitiveTypeGenerator> _primitiveTypeGenerators;
        private List<Type> SystemTypes;
        public Faker()
        {
            SystemTypes = typeof(Assembly).Assembly.GetExportedTypes().ToList();
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
            else if (objectType.IsClass)
            {
                foreach (var constructor in objectType.GetConstructors())
                {
                    
                }
                
            } 
            else
            {
                generatedType = null;
            }
            

            return generatedType;
        }
    }
}