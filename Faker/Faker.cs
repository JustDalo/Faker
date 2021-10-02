using System;
using System.Collections.Generic;
using System.Dynamic;
using Faker.ValueGenerator;
using Faker.ValueGenerator.PrimitiveTypes;

namespace Faker
{
    public class Faker
    {
        private Dictionary<Type, IPrimitiveTypeGenerator> _generators;
        
        public Faker()
        {
            
        }
        
        public T Create<T>() where T : class
        {
            var type = typeof(T);
               
            return null;
        }

        private void Create(Type objectType)
        {
            
        }
    }
}