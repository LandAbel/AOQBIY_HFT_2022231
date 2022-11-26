using AOQBIY_HFT_2022231.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;

namespace AOQBIY_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;

        static void List(string entity)
        {
            if (entity == "Processor")
            {
                List<Processor> proce = rest.Get<Processor>("processor");
                foreach (var item in proce)
                {
                    Console.WriteLine(item.ProcessorId + "\t" + item.Name);
                }
            }
            if (entity == "Chipsets")
            {
                List<Chipsets> chip = rest.Get<Chipsets>("chipsets");
                foreach (var item in chip)
                {
                    Console.WriteLine(item.ChipsetId + "\t" + item.Name);
                }
            }
            if (entity == "Brand")
            {
                List<Brand> brand = rest.Get<Brand>("brand");
                foreach (var item in brand)
                {
                    Console.WriteLine(item.BrandId + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            if (entity == "Processor")
            {
                Console.Write("Enter Processor Name:");
                string name = Console.ReadLine();
                rest.Post(new Processor() { Name = name }, "processor");

            }
            if (entity == "Chipsets")
            {
                Console.Write("Enter Chipsets Name:");
                string name = Console.ReadLine();
                rest.Post(new Chipsets() { Name = name }, "chipsets");

            }
            if (entity == "Brand")
            {
                Console.Write("Enter Brand Name:");
                string name = Console.ReadLine();
                rest.Post(new Brand() { Name = name }, "Brand");

            }
        }
        static void Update(string entity)
        {
            if (entity == "Processor")
            {
                Console.Write("Enter Processor id to update:");
                int id = int.Parse(Console.ReadLine());
                Processor first = rest.Get<Processor>(id, "processor");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "processor");
            }
            if (entity == "Chipsets")
            {
                Console.Write("Enter Chipsets id to update:");
                int id = int.Parse(Console.ReadLine());
                Chipsets first = rest.Get<Chipsets>(id, "chipsets");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "chipsets");
            }
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to update:");
                int id = int.Parse(Console.ReadLine());
                Brand first = rest.Get<Brand>(id, "brand");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "brand");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Processor")
            {
                Console.WriteLine("Enter Processor id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "processor");
            }
            if (entity == "Chipsets")
            {
                Console.WriteLine("Enter Chipsets id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "chipsets");
            }
            if (entity == "Brand")
            {
                Console.WriteLine("Enter Brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:25922/", "processor");


            var ProcessorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Processor"))
                .Add("Create", () => Create("Processor"))
                .Add("Delete", () => Delete("Processor"))
                .Add("Update", () => Update("Processor"))
                .Add("Exit", ConsoleMenu.Close);

            var ChipsetsSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Chipsets"))
                .Add("Create", () => Create("Chipsets"))
                .Add("Delete", () => Delete("Chipsets"))
                .Add("Update", () => Update("Chipsets"))
                .Add("Exit", ConsoleMenu.Close);

            var BrandSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);
            var DataStatisticsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List All Processors on z690", () => q1())
                .Add("INTEL Processors With More than 30MB Cache", () => q2())
                .Add("INTEL Processors With Integrated Graph", () => q3())
                .Add("Max Turbo Freq More Then 4.9 Processor From AMD", () => q4())
                .Add("Mobile Processors With More Than 6 Core", () => q5())
                .Add("Intel Processors With More Than 30 Threads", () => q6())
                .Add("Processors By Brand", () => q7())
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Processor", () => ProcessorSubMenu.Show())
                .Add("Chipsets", () => ChipsetsSubMenu.Show())
                .Add("Brand", () => BrandSubMenu.Show())
                .Add("Data Statistics",()=>DataStatisticsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
        static void q1()
        {
            Console.WriteLine("List all Z690 Processors");
            List<Processor> pro=rest.Get<Processor>("Statistics/z790ProcessorsWith10Core");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q2()
        {
            Console.WriteLine("INTEL Processors With More than 30MB Cache");
            List<Processor> pro = rest.Get<Processor>("Statistics/INTELProcessorsWithMorethan30mbCache");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q3()
        {
            Console.WriteLine("INTEL Processors With Integrated Graph");
            List<Processor> pro = rest.Get<Processor>("Statistics/INTELProcessorsWithIntegratedGraph");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q4()
        {
            Console.WriteLine("Max Turbo Freq More Then 4.9 Processor From AMD");
            List<Processor> pro = rest.Get<Processor>("Statistics/MaxTurboFreqMoreThen49ProcessorFromAMD");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q5()
        {
            Console.WriteLine("Mobile Processors With More Than 6 Core");
            List<Processor> pro = rest.Get<Processor>("Statistics/MobileProcessorsWithMoreThan6Core");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q6()
        {
            Console.WriteLine("Intel Processors With More Than 30 Threads");
            List<Processor> pro = rest.Get<Processor>("Statistics/IntelProcessorsWithMoreTh30Threads");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q7()
        {
            Console.WriteLine("Processors By Brands");
            List<Processor.ProcessorInfo> pro = rest.Get<Processor.ProcessorInfo>("Statistics/ProcessorsByBrands");
            foreach (var item in pro)
            {
                Console.WriteLine("Brand \t AvgCore \t Number");
                Console.WriteLine($"{item.Brand} \t {item.AvgCore} \t {item.Number}");
            }
            Console.ReadLine();
        }

    }
}
