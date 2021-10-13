using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using Faker.ValueGenerator;
using Faker.ValueGenerator.PrimitiveTypes;
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
        public Dictionary<PropertyInfo, IPrimitiveTypeGenerator> customGenerators;
        
        private Stack<Type> createdTypes;
        public Faker()
        {
            createdTypes = new Stack<Type>();
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
                {typeof(char), LoadPlugin(@"C:\Users\ASUS\RiderProjects\MPPproject2\CharGenerator\bin\Debug\net5.0\CharGenerator.dll", typeof(char))},
                {typeof(string), new StringGenerator()},
                {typeof(DateTime), LoadPlugin(@"C:\Users\ASUS\RiderProjects\MPPproject2\DataTimeGenerator\bin\Debug\net5.0\DataTimeGenerator.dll", typeof(DateTime))}
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
            object generatedType = null;
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
                
                if (!createdTypes.Contains(objectType))
                {
                    createdTypes.Push(objectType);
                    generatedType = CreateByConstructorAndProps(objectType, constructorToUse);
                    createdTypes.Pop();
                }
                else
                {
                    CycleException();
                }
            }
            else
            {
                generatedType = null;
            }
            return generatedType;
        }
        private object CreateByConstructorAndProps(Type objectType, ConstructorInfo constructor)
        {
            var constructorValues = new List<object>();
            object value;
            object generated = null;

            if (constructor != null)
            {
                foreach (var parameterInfo in constructor.GetParameters())
                {
                    value = Create(parameterInfo.ParameterType);
                    constructorValues.Add(value);
                }
                
                generated = (object) Activator.CreateInstance(constructor.ReflectedType, constructorValues.ToArray());
            }
            else
            {
                generated = Activator.CreateInstance(objectType);
            }
            foreach (FieldInfo fieldInfo in objectType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                object propertyValue = Create(fieldInfo.FieldType);
                fieldInfo.SetValue(generated, propertyValue);
            }
            return generated;
        }
        
        private IPrimitiveTypeGenerator LoadPlugin(string path, Type generatorType)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes();
            foreach (var type in types)
            { 
                var inst = (IPrimitiveTypeGenerator)Activator.CreateInstance(type);
                return inst;
               
            }
            return null;
        }

        private void CycleException()
        {
            throw new Exception("A cyclical relationship was found");
        }
    }
}