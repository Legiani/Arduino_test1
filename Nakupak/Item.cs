using System;
using System.Threading.Tasks;
using SQLite;

namespace Nakupak
{
	public class Item
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }

		public override string ToString()
		{
			return Name + " " + Price + " " + Quantity;
		}

		public static explicit operator Item(Task<Item> v)
		{
			throw new NotImplementedException();
		}
	}
}
