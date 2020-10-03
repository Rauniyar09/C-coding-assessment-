using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return string.Format($"Name: {Name}\nId: {Id}\nAddress: {Address}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Read or Write? (R/W): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "w")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Employee e = new Employee { Name = "Rahul", Id = 201, Address = "Kathmandu" };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream f = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(f, e);
            f.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Employee e1 = bf.Deserialize(fs) as Employee;
            Console.WriteLine(e1.Name);
            Console.WriteLine(e1.Id);
            Console.WriteLine(e1.Address);
            fs.Close();
        }
    }
}
