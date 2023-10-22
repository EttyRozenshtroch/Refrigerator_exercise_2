using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Refrigerator> refrigeratorsList = new List<Refrigerator>();
            application(refrigeratorsList);
        }
        static public void application(List<Refrigerator> refrigeratorsList)
        {
            int _choise = 0;
            Refrigerator refrigerator = new Refrigerator("VX:55856",ColorRefrigerator.white,6);
            while (_choise != 100)
            {
                Console.WriteLine("Menue");
                try
                {
                    _choise = Int32.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                switch (_choise)
                {
                    case 1:
                        Console.WriteLine(refrigerator);
                        break;
                    case 2:
                        Console.WriteLine(refrigerator.getFreeSpace());
                        break;
                    case 3:                       
                        refrigerator.addItem(buildItemByInput());
                        break;
                    case 4:
                        removeItemFromRefrigerator(refrigerator);
                        break;
                    case 5:
                        refrigerator.cleanRefrigerator();
                        break;
                    case 6:
                        getWhatToEat(refrigerator);
                        break;
                    case 7:
                        List<Item> orderItems = refrigerator.sortItemByExpiredDate();
                        foreach(Item item in orderItems)
                            Console.WriteLine(item);
                        break;
                    case 8:
                        List<Shelf> orderShelves = refrigerator.sortShelvesByFeeSpace();
                        foreach(Shelf shelf in orderShelves)
                            Console.WriteLine(shelf);
                        break;
                    case 9:
                        sortRefrigitorByFeeSpace(refrigeratorsList);
                        break;
                    case 10:
                        refrigerator.preparingForShopping();
                        break;
                    case 100:
                        break;
                    default:
                        break;
                }
            }
        }

        public static Item buildItemByInput()
        {
            TypeItem typeItem=0;
            Kashrut kashrut=0;
            DateTime expirationDate=DateTime.Now;
            bool flag = false;
            double area=0;
            Console.WriteLine("Please enter the name of the item");
            string name = Console.ReadLine();
            while (!flag)
            {
                Console.WriteLine("Please enter the type of the item - food or drink");
                try
                {
                    typeItem = (TypeItem)Enum.Parse(typeof(TypeItem), Console.ReadLine());
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                }
            }
            flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter the Kashrut of the item -  meat, dairy or fur");
                try
                {
                    kashrut = (Kashrut)Enum.Parse(typeof(Kashrut), Console.ReadLine());
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                }
            }
            flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter the date of the expiration date");
                try
                {
                    expirationDate = DateTime.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                }
            }
            flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter the area of the item");
                try
                {
                    area = double.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                }
            }
            return new Item(name, typeItem, kashrut, expirationDate, area);
        }
        public static void removeItemFromRefrigerator(Refrigerator refrigerator)
        {
            int itemId=0;
            Console.WriteLine("Please enter the ID of the item you want to remove from the refrigerator");
            try
            {
                itemId = int.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+"\nplase try again.");
            }
            Item item =refrigerator.removeItem(itemId);
            if (item != null)
            {
                Console.WriteLine(item + " removed");
            }
            else
            {
                Console.WriteLine("item with id " + itemId + " not found");
            }
        }
        public static void getWhatToEat(Refrigerator refrigerator)
        {
            Kashrut kashrut=0;
            TypeItem typeItem = 0;
            bool flag = false;
            Console.WriteLine("Please enter the type of the item - food or drink");
            while (!flag)
            {
                try
                {
                    typeItem = (TypeItem)Enum.Parse(typeof(TypeItem), Console.ReadLine());
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                }
            }
            Console.WriteLine("Please enter the Kashrut of the item -  meat, dairy or fur");
            flag = false;
            while (!flag)
            {
                try
                {
                    kashrut = (Kashrut)Enum.Parse(typeof(Kashrut), Console.ReadLine());
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                }
            }
            List<Item> itemsToEat = refrigerator.getWhatToEat(kashrut,typeItem);
            foreach (Item item in itemsToEat)
            {
                Console.WriteLine("---");
                Console.WriteLine(item);
            }
        }
        public static List<Refrigerator> sortRefrigitorByFeeSpace(List<Refrigerator> refrigeratorsList)
        {
            List<Refrigerator> sortedList = refrigeratorsList;
            sortedList.OrderBy(o => o.getFreeSpace());
            sortedList.Reverse();
            return sortedList;
        }
    }
}
