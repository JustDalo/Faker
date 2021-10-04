using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Faker.ValueGenerator;
using Faker.ValueGenerator.PrimitiveTypes;
using Faker.ValueGenerator.PrimitiveTypes.CharType;
using Faker.ValueGenerator.PrimitiveTypes.IntegerTypes;
using Faker.ValueGenerator.PrimitiveTypes.LogicalType;
using Faker.ValueGenerator.ReferenceTypes.GenericType;
using Faker.ValueGenerator.ReferenceTypes.StringType;

namespace Faker
{
    public class Faker
    {
        private Dictionary<Type, IPrimitiveTypeGenerator> _primitiveTypeGenerators;
        private Dictionary<Type, IGenericTypeGenerator> _genericTypeGenerators;
        public Faker()
        {
            //SystemTypes = typeof(Assembly).Assembly.GetExportedTypes().ToList();
            _primitiveTypeGenerators = new Dictionary<Type, IPrimitiveTypeGenerator>()
            {
                {typeof(bool), new BooleanGenerator()},
                {typeof(int), new IntegerGenerator()},
                {typeof(long), new LongGenerator()},
                {typeof(sbyte), new SByteGenerator()},
                {typeof(short), new ShortGenerator()},
                {typeof(uint), new UIntegerGenerator()},
                {typeof(ulong), new ULongGenerator()},
                {typeof(ushort), new UShortGenerator()},
                {typeof(char), new CharGenerator()},
                {typeof(string), new StringGenerator()},
            };
            _genericTypeGenerators = new Dictionary<Type, IGenericTypeGenerator>()
            {
                {typeof(List<>), new ListGenerator(_primitiveTypeGenerators)}
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
            else if (objectType.IsGenericType && _genericTypeGenerators.TryGetValue(objectType.GetGenericTypeDefinition(), out IGenericTypeGenerator genericTypeGenerator))
            {
                generatedType = genericTypeGenerator.Generate(objectType.GenericTypeArguments[0]);
            }
            else if (objectType.IsClass)
            {
                int maxConstructorFieldsCount = 0, curConstructorFieldsCount;
                ConstructorInfo constructorToUse = null;
                foreach (var constructor in objectType.GetConstructors())
                {
                    curConstructorFieldsCount = constructor.GetParameters().Length;
                    if (curConstructorFieldsCount > maxConstructorFieldsCount)
                    {
                        maxConstructorFieldsCount = curConstructorFieldsCount;
                        constructorToUse = constructor;
                    }
                }

                if (constructorToUse == null)
                {
                    generatedType = CreateByProperties(objectType);
                }
                else
                {
                    generatedType = CreateByConstructor(objectType, constructorToUse);
                }
            }
            else
            {
                generatedType = null;
            }
            return generatedType;
        }

        private object CreateByProperties(Type objectType)
        {
            object generated = Activator.CreateInstance(objectType);
            foreach (FieldInfo fieldInfo in objectType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
            {   
                Console.WriteLine(fieldInfo);
                object value = Create(fieldInfo.FieldType);
                fieldInfo.SetValue(generated, value);
            }

            return generated;
        }

        private object CreateByConstructor(Type objectType, ConstructorInfo constructor)
        {
            var parametersValues = new List<object>();
            object value;
            foreach (var parameterInfo in constructor.GetParameters())
            {
                value = Create(parameterInfo.ParameterType);
                parametersValues.Add(value);
            }

            try
            {
                return constructor.Invoke(parametersValues.ToArray());
            }
            catch (Exception e)
            {   
                Console.Write("Error");
                return null;
            }
        }
    }
}