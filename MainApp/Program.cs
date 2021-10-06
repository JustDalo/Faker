using System;
using System.Collections.Generic;


namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker.Faker();
          //  int l = faker.Create<int>();
            DateTime time = faker.Create<DateTime>();
            //Foo foo = faker.Create<Foo>();
            Console.ReadLine();
        }
    }

    public class Foo
    {
        public DateTime datetime;
        public bool isFalse;
        public string name1;
        private string name2;
        private Bar bar;
        private List<int> gjfj;

        
       // public DateTime _dateTime;

        public int age;

        // public Foo(bool isFalse, string name, Bar bar)
        // {
        //     this.isFalse = isFalse;
        //     this.name2 = name;
        //     this.bar = bar;
        // }

        public class Bar
        {
            public int age;
           // public Foo foo;
        }
    }

}