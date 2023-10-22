using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    internal class Shelf
    {
        private static int _numberOfShlfs = 0;
        private int _id;
        private int _floorNumber;
        private double _area;
        private List<Item> _items;

        public Shelf()
        {
            this._id = ++_numberOfShlfs;
            this._floorNumber = 1;
            this._area = 2;
            this._items = new List<Item>();
            this._items.Add(new Item());
        }
        public Shelf(int floorNumber, double shlfArea)
        {
            _id =++_numberOfShlfs;
            this.floorNumber = floorNumber;
            this.area = shlfArea;
            _items = new List<Item>();
        }

        public int id
        {
            get { return this._id; }
        }
        public int floorNumber
        {
            get { return this._floorNumber; }
            set
            {
                if (value > 0 && value < 7)
                    this._floorNumber = value;
                this._floorNumber = value;
            }
        }
        public double area
        {
            get { return this._area; }
            set
            {
                if (value > 0)
                    this._area = value;
                else
                    this._area = 1;
            }
        }
        public List<Item> items
        { get { return this._items; } }
        public override string ToString()
        {
            string itemsString = "\n";
            foreach (var item in this._items)
            {
                itemsString += "  *" + item.ToString() + "\n";
            }
            return "The ID of the shlf is:" + this._id + ".\nThe floor number of the shelf is:" + this._floorNumber +
                "\nThe area of the shlf is:" + this._area + "\nThe list f items in the shelf: " + itemsString;
        }
        public bool addItem(Item item)
        {
            if (item.area <= this.getFreeSpace())
            {
                this._items.Add(item);
                item.shlfID=this._id;
                return true;
            }
            return false;
        }
        public Item removeItem(int itemId)
        {
            Item itemToReturn = null;
            int numberOfItems = this._items.Count;               
            for (int i = 0; i < numberOfItems; i++)
            {
                if (this._items[i].id==itemId)
                {
                    itemToReturn = this._items[i];
                    this._items.Remove(this._items[i]);
                    break;
                }
            }
            return itemToReturn;
        }
        public void cleanSelf()
        {
            int numberOfItems = this._items.Count;
            for (int i = 0; i < numberOfItems; i++)
            {
                if (this._items[i].expirationDate < DateTime.Today)
                {
                    this._items.Remove(this._items[i]);
                    numberOfItems--;
                }
            }
        }
        public void cleanSelfByType(Kashrut kashrut, int days)
        {
            int numberOfItems = this._items.Count;
            for (int i = 0; i < numberOfItems; i++)
            {
                if (this._items[i].kashrut == kashrut && this._items[i].expirationDate < DateTime.Today.AddDays(days))
                {
                    this._items.Remove(this._items[i]);
                    numberOfItems--;
                }
            }
        }
        public double getFreeSpace()
        {
            double freeSpace = this._area;
            foreach (var item in _items)
            {
                freeSpace -= item.area;
            }
            return freeSpace;
        }
        public double getHowMuchSpaceWillBeFree(Kashrut kashrut, int days)
        {
            double HowMuchSpaceWillBeFree = 0;
            foreach (var item in this._items)
            {
                if (item.kashrut == kashrut && item.expirationDate < DateTime.Today.AddDays(days))
                    HowMuchSpaceWillBeFree += item.area;
            }
            return HowMuchSpaceWillBeFree;
        }
        public List<Item> getWhatToEat(Kashrut kashrut, TypeItem itemType)
        {
            List<Item> itemsToEat = new List<Item>();
            foreach (var item in this._items)
            {
                if (item.type == itemType && item.kashrut == kashrut && item.expirationDate > DateTime.Today)
                {
                    itemsToEat.Add(item);
                }
            }
            return itemsToEat;
        }

    }
}
