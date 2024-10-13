using LiteDB;

namespace APM_Counter.Data; 

public class LiteDatabaseActionStorage : IActionStorage {
	private ILiteDatabase _database;
	private ILiteCollection<MyAction> _collection;

	public LiteDatabaseActionStorage(ILiteDatabase liteDatabase) => _database = liteDatabase;

		public Task<int> GetActionCount(DateTimeOffset since, DateTimeOffset until) {
			var count = _collection.Find(action => action.Timestamp >= since && action.Timestamp <= until).Count();
			
			return Task.FromResult(count);
	}

	public Task Store(MyAction action) {
		var collection = _database.GetCollection<MyAction>("actions");
		collection.Insert(action);
		return Task.CompletedTask;
	}
}


