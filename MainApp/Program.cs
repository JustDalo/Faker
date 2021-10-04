using System;
using System.Collections.Generic;


namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker.Faker();
            Foo foo = faker.Create<Foo>();
            List<string> stringList = faker.Create<List<string>>();
            // var bar = faker.Create<Bar>();
            Console.WriteLine(foo.ToString());
        }
    }

    public class Foo
    {
        public bool isFalse;
        public string name1;
        private string name2;
        private Bar bar;

        public int age;
        public Foo(bool isFalse, string name, Bar bar)
        {
            this.isFalse = isFalse;
            this.name2 = name;
            this.bar = bar;
        }
    }

    public class Bar
    {
        public int age;
    }
    
}