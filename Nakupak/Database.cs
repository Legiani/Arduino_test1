using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Nakupak
{
	public class Database
	{
		private SQLiteAsyncConnection database;

		public Database(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Item>().Wait();
		}

		public Task<List<Item>> GetItemsAsync()
		{
			return database.Table<Item>().ToListAsync();
		}

		public Task<List<Item>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<Item>("SELECT * FROM [Nakupak.db3] WHERE [Done] = 0");
		}

		public Task<Item> GetItemAsync(int id)
		{
			return database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(Item item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(Item item)
		{
			return database.DeleteAsync(item);
		}

	}
}
