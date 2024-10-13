namespace APM_Counter.Data;

public class MemoryActionStorage : IActionStorage {
	private readonly List<MyAction> _actionList = new();

	public Task<int> GetActionCount(DateTimeOffset since, DateTimeOffset until) {
		var count = _actionList.Count(action => action.Timestamp >= since && action.Timestamp <= until);
		return Task.FromResult(count);
	}

	public Task Store(MyAction action) {
		_actionList.Add(action);
		return Task.CompletedTask;
	}
}
