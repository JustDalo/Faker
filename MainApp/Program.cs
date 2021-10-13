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
            Console.ReadLine();
        }
    }

    public class Foo
    {
        public DateTime datetime;
        
        private bool isFalse;
        public string name1;
        private string name2;
        private Bar bar;
        private List<int> gjfj;
        public int age;
        public IEnumerable<int> enumList;

        public Foo(bool isFalse, string name, Bar bar)
        {
            this.isFalse = isFalse;
            this.name2 = name;
            this.bar = bar;
        }
    }
    
    public class Bar
    {
        public char symbol;
        public int age;
        //public Foo foo;
    }
    

}