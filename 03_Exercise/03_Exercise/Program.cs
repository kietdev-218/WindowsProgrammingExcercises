using System;
using System.Collections;
using System.Collections.Generic;

namespace _03_Exercise
{
    class Program
    {
        static DateTime InputDateTime()
        {
            Console.WriteLine("Day: ");
            int day = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Month: ");
            int month = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Year: ");
            int year = Int32.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);
            return date;
        }

        static int IndexMove()
        {
            Console.WriteLine("Move to index: ");
            int index = Int32.Parse(Console.ReadLine());
            return index;
        }

        static string GetName()
        {
            Console.WriteLine("What is pet name: ");
            string name = Console.ReadLine();
            return name;
        }

        static string GetColor()
        {
            Console.WriteLine("What color your dog : ");
            string color = Console.ReadLine();
            return color;
        }

        static void Main(string[] args)
        {
              List<IAnimal> animal = new List<IAnimal>();
              int select;
              string color;
              do
              {
                  Console.WriteLine("1. Monkey");
                  Console.WriteLine("2. Cat");
                  Console.WriteLine("3. Dog");
                  Console.WriteLine("4. Exit");
                  select = int.Parse(Console.ReadLine());
                  switch (select)
                  {
                    case 1:
                        Monkey monkey = new Monkey();
                        monkey.Brithdate = InputDateTime();
                        monkey.Move = IndexMove();
                        animal.Add(monkey);
                        break;
                    case 2:
                        Cat cat = new Cat();
                        cat.Brithdate = InputDateTime();
                        cat.Move = IndexMove();
                        cat.Name = GetName();
                        animal.Add(cat);
                        break;
                    case 3:
                        Dog dog = new Dog();
                        dog.Brithdate = InputDateTime();
                        dog.Move = IndexMove();
                        dog.Name = GetName();
                        dog.Color = GetColor();
                        animal.Add(dog);
                        break;
                  }
              } 
              while (select != 4);

            foreach(IAnimal item in animal)
            {
                switch (item.GetType())
                {
                    case 1:
                        Console.WriteLine("---------------- MONKEY----------------");
                        item.Speak();
                        Console.WriteLine($"Birthdate: {item.Brithdate}");
                        ((Monkey)item).Climb();
                        Console.WriteLine($"Monkey move to {item.Move}");
                        break;
                    case 2:
                        Console.WriteLine("---------------- CAT ----------------");
                        Console.WriteLine($"Name: {((Cat)item).Name}");
                        Console.WriteLine($"Birthdate: {item.Brithdate}");
                        item.Speak();
                        ((Cat)item).Jump();
                        Console.WriteLine($"Cat move to {item.Move}");
                        break;
                    case 3:
                        Console.WriteLine("---------------- DOG ----------------");
                        Console.WriteLine($"Name: {((Dog)item).Name}");
                        Console.WriteLine($"Birthdate: {item.Brithdate}");
                        item.Speak();
                        Console.WriteLine($"Dog move to {item.Move}");
                        Console.WriteLine($"Dog is color {((Dog)item).Color}");
                        break;
                }
            }
        }
    }
}
