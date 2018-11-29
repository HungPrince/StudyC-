using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            //var numQuery =
            //    from num
            //    in numbers
            //    where (num % 2) == 0
            //    orderby num descending
            //    select num;
            //foreach (var num in numQuery)
            //{
            //    Console.WriteLine(num);
            //}

            //IEnumerable<Customer> customer = new Customer[]
            //{
            //    new Customer(1, "HungPrince", "VN"),
            //     new Customer(2, "Tan", "VN"),
            //      new Customer(3, "Nam", "USA"),
            //       new Customer(4, "An", "ENG"),
            //};
            //var queryCustomer =
            //    from cus
            //    in customer
            //    group cus by cus.City
            //    into cus
            //    where cus.Count() > 1
            //    select cus;

            //foreach (var customerGroup in queryCustomer)
            //{
            //    Console.WriteLine(customerGroup.Key);
            //    foreach (Customer cust in customerGroup)
            //    {
            //        Console.WriteLine(cust.Name);
            //    }
            //}

            List<Student> students = new List<Student>()
            {
                new Student {First="Svetlana",
                Last="Omelchenko",
                ID=111,
                Street="123 Main Street",
                City="Seattle",
                Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire",
                Last="O’Donnell",
                ID=112,
                Street="124 Main Street",
                City="Redmond",
                Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven",
                Last="Mortensen",
                ID=113,
                Street="125 Main Street",
                City="Lake City",
                Scores= new List<int> {88, 94, 65, 91}},
            };

            //List<Teacher> teachers = new List<Teacher>()
            //{
            //    new Teacher {First="Ann", Last="Beebe", ID=945, City = "Seattle"},
            //    new Teacher {First="Alex", Last="Robinson", ID=956, City = "Redmond"},
            //    new Teacher {First="Michiyo", Last="Sato", ID=972, City = "Tacoma"}
            //};

            //var peopleInSeattle = (from student in students
            //                       where student.City == "Seattle"
            //                       select student.Last)
            //                       .Concat(from teacher in teachers
            //                               where teacher.City == "Seattle"
            //                               select teacher.Last);
            //Console.WriteLine("The following students and teachers live in Seattle");
            //foreach (var person in peopleInSeattle)
            //{
            //    Console.WriteLine(person);
            //}

            //Tranforming in-Memory Objects into XML
            //var studentsToXML = new XElement("Root",
            //    from student in students
            //    let x = String.Format("{0}, {1}, {2}, {3}", student.Scores[0], student.Scores[1], student.Scores[2], student.Scores[3])
            //    select new XElement("Student",
            //    new XElement("First", student.First),
            //    new XElement("Last", student.Last),
            //    new XElement("Scores", x))
            //    );
            //Console.WriteLine(studentsToXML);
            //Console.WriteLine("Press any key to exit");

            List<Category> categories = new List<Category>()
                {
                    new Category(){Name="Beverages", ID=001},
                    new Category(){ Name="Condiments", ID=002},
                    new Category(){ Name="Vegetables", ID=003},
                    new Category() {  Name="Grains", ID=004},
                    new Category() {  Name="Fruit", ID=005}
                };

            List<Product> products = new List<Product>()
               {
                  new Product{Name="Cola",  CategoryID=001},
                  new Product{Name="Tea",  CategoryID=001},
                  new Product{Name="Mustard", CategoryID=002},
                  new Product{Name="Pickles", CategoryID=002},
                  new Product{Name="Carrots", CategoryID=003},
                  new Product{Name="Bok Choy", CategoryID=003},
                  new Product{Name="Peaches", CategoryID=005},
                  new Product{Name="Melons", CategoryID=005},
                };

            var innerJoin = from category in categories
                            join poroduct in products
                            on category.ID equals poroduct.CategoryID
                            select new
                            {
                                Category = category.ID,
                                Product = poroduct.Name
                            };

            var groupJoin = from category in categories
                            join prod in products
                            on category.ID equals prod.CategoryID
                            into prodGroup
                            select prodGroup;

            int totalItems = 0;
            //foreach (var prodGrouping in groupJoin)
            //{
            //    Console.WriteLine("Group:");
            //    foreach (var item in prodGrouping)
            //    {
            //        totalItems++;
            //        Console.WriteLine("   {0,-10}{1}", item.Name, item.CategoryID);
            //    }
            //}

            //Console.WriteLine("Unshaped GroupJoin: {0} items in {1} unnamed groups", totalItems, groupJoin.Count());
            //Console.WriteLine(System.Environment.NewLine);

            var groupInnerJoin = from category in categories
                                 orderby category.ID
                                 join product in products
                                 on category.ID equals product.CategoryID
                                 into prodGroup
                                 select new
                                 {
                                     Category = category.Name,
                                     Products = from prod2 in prodGroup
                                                orderby prod2.Name
                                                select prod2
                                 };

            Console.WriteLine("GroupInnerJoin:");
            foreach (var productGroup in groupInnerJoin)
            {
                Console.WriteLine(productGroup.Category);
                foreach (var prodItem in productGroup.Products)
                {
                    totalItems++;
                    Console.WriteLine("  {0,-10} {1}", prodItem.Name, prodItem.CategoryID);
                }
            }
            Console.WriteLine("GroupInnerJoin: {0} items in {1} named groups", totalItems, groupInnerJoin.Count());
            Console.WriteLine(System.Environment.NewLine);

            Console.ReadKey(true);
        }
    }

    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Customer(int _ID, string _Name, string _City)
        {
            this.ID = _ID;
            this.Name = _Name;
            this.City = _City;
        }
    }

    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<int> Scores;
    }

    class Teacher
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }

    class Category
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
