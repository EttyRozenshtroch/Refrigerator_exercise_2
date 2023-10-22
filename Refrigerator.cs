using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    public enum ColorRefrigerator { gray, white, black }
    internal class Refrigerator
    {
        private static int _numberOfRefrigerator = 0;
        private int _id;
        private string _model;
        private ColorRefrigerator _color;
        private int _numberOfShelves;
        private Shelf[] _listOfshelves;


        public Refrigerator()
        {
            this._id = ++_numberOfRefrigerator;
            this._model = "aaa" + this._id;
            this._color = ColorRefrigerator.white;
            this._numberOfShelves = 5;
            this._listOfshelves = new Shelf[this._numberOfShelves];
            for (int i = 0; i < this._numberOfShelves; i++) { this._listOfshelves[i] = new Shelf(); }
        }
        public Refrigerator(string modelR,ColorRefrigerator colorR,int numberOfShelves)
        {
            this._id = ++_numberOfRefrigerator;
            this.model = modelR;
            this._color = colorR;
            this._numberOfShelves = numberOfShelves;
            this._listOfshelves = new Shelf[this._numberOfShelves];
            for (int i = 0; i < this._numberOfShelves; i++)
            {
                this._listOfshelves[i] = new Shelf(i,55);
            }
        }
        public int id
        { 
            get { return _id; }
        }
        public string model
        {
            get { return this._model; }
            set
            {
                if (value == "" || value == null)
                    this._model = "unknowen";
                else
                    this._model = value;
            }
        }
        public ColorRefrigerator color
        { 
            get { return this._color; } 
            set { this._color = value; }
        }
        public int numberOfShrlfs
        { 
            get { return this._numberOfShelves; } 
            set 
            { 
                if(value>0&&value<7)
                    this._numberOfShelves = value;
                else
                    this._numberOfShelves = 4;
            } 
        }
        public Shelf[] listOfshelves { get { return this._listOfshelves; } }

        public override string ToString()
        {
            string shlfsString = "\n";
            foreach (var shelf in _listOfshelves)
            {
                shlfsString += "  *" + shelf.ToString() + "\n";
            }
            return "The ID of the refrigerator is"+this._id+".\nThe model of the refrigerator is:"+this._model+".\n" +
                "The color of the refrigerator is:"+this._color+".\nThe numberOfShlfs of the refrigerator is:"+this._numberOfShelves +".\n" +
                "The list of shelfs in the refrigerator is:"+shlfsString;
        }
        public void addItem(Item item)
        {
            for (int i = 0; i < this._listOfshelves.Length; i++)
            {
                if (this._listOfshelves[i].addItem(item))
                    return;
            }
        }
        public Item removeItem(int itemId)
        {
            Item tempItem;
            foreach (var shelf in this._listOfshelves)
            {
                tempItem = shelf.removeItem(itemId);
                if (tempItem != null)
                    return tempItem;
            }
            return null;
        }
        public void cleanRefrigerator()
        {
            foreach(var  shelf in this._listOfshelves)
            {
                shelf.cleanSelf();
            }
        }
        public void cleanRefrigeratorByType(Kashrut kashrut,int days)
        {
            foreach (var shelf in this._listOfshelves)
            {
                shelf.cleanSelfByType(kashrut,days);
            }
        }
        public double getFreeSpace()
        {
            double freeSpace = 0;
            foreach (var shelf in _listOfshelves)
            {
                freeSpace += shelf.getFreeSpace();
            }
            return freeSpace;
        }
        public double getHowMuchSpaceWillBeFree(Kashrut kashrut,int days)
        {
            double HowMuchSpaceWillBeFree = 0;
            foreach (var shelf in this._listOfshelves)
            {
                HowMuchSpaceWillBeFree += shelf.getHowMuchSpaceWillBeFree(kashrut,days);
            }
            return HowMuchSpaceWillBeFree;
        }

        public void preparingForShopping()
        {
            double freeSpace;
            freeSpace = getFreeSpace();
            if (freeSpace >= 20)
            {
                Console.WriteLine("There's enough of space in the refrigerator. You can go shopping :)");
                return;
            }
            this.cleanRefrigerator();
            Console.WriteLine("We removed the expired items.");
            freeSpace = getFreeSpace();
            if (freeSpace >= 20)
            {
                Console.WriteLine("There's enough of space in the refrigerator. You can go shopping :)");
                return;
            }
            freeSpace = getFreeSpace();
            freeSpace += this.getHowMuchSpaceWillBeFree(Kashrut.dairy,3);
            if (freeSpace >=20)
            {
                this.cleanRefrigeratorByType(Kashrut.dairy,3);
                Console.WriteLine("We removed the dairy items whose validity is about to expire in three days");
                Console.WriteLine("There's enough of space in the refrigerator. You can go shopping :)");
                return;
            }
            freeSpace += this.getHowMuchSpaceWillBeFree(Kashrut.meat,3);
            if (freeSpace >= 20)
            {
                Console.WriteLine("We removed the dairy items whose validity is about to expire in three days");
                this.cleanRefrigeratorByType(Kashrut.dairy, 3);
                Console.WriteLine("We removed the meat items whose validity is about to expire in three days");
                this.cleanRefrigeratorByType(Kashrut.meat, 3);
                Console.WriteLine("There's enough of space in the refrigerator. You can go shopping :)");
                return;
            }
            freeSpace += this.getHowMuchSpaceWillBeFree(Kashrut.fur, 1);
            if (freeSpace >= 20)
            {
                Console.WriteLine("We removed the dairy items whose validity is about to expire in three days");
                this.cleanRefrigeratorByType(Kashrut.dairy, 3);
                Console.WriteLine("We removed the meat items whose validity is about to expire in three days");
                this.cleanRefrigeratorByType(Kashrut.meat, 3);
                Console.WriteLine("We removed the fur items whose validity is about to expire in one day");
                this.cleanRefrigeratorByType(Kashrut.meat, 3);
                Console.WriteLine("There's enough of space in the refrigerator. You can go shopping :)");
                return;
            }
            Console.WriteLine("The refrigerator is full. This is not the time to shoping :(");
            return;
        }
        public List<Item> getWhatToEat(Kashrut kashrut, TypeItem itemType)
        {
            List<Item> itemsToEat = new List<Item>();// The final list of the items that fit the requirements
            List<Item> whatToEat= new List<Item>(); //The list of the items that fit the requirements in a specific shelf
            foreach (Shelf shelf in this._listOfshelves)
            {
                whatToEat = shelf.getWhatToEat(kashrut, itemType);
                foreach(Item item in whatToEat)
                {
                    itemsToEat.Add(item);
                }
            }
            return itemsToEat;            
        }
        public List<Item> sortItemByExpiredDate()
        {
            List<Item> allItemsOnlist = new List<Item>();
            foreach (Shelf shelf in this.listOfshelves)
            {
                allItemsOnlist.AddRange(shelf.items);
            }

            List<Item> SortedList = allItemsOnlist.OrderBy(o => o.expirationDate).ToList();
            return SortedList;
        }
        public List<Shelf> sortShelvesByFeeSpace()
        {
            List<Shelf> sortedList = new List<Shelf>(); 
            sortedList.AddRange(this.listOfshelves);
            sortedList.OrderBy(o => o.getFreeSpace());
            sortedList.Reverse();
            return sortedList;
        }
    }
}


