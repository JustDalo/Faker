using System;


namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker.Faker();
            Foo foo = faker.Create<Foo>();
           // var bar = faker.Create<Bar>();
        }
    }

    public class Foo
    {
        public Foo()
        {
            
        }

        private Boolean isFalse;
    } 
    
}