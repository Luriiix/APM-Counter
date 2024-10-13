namespace APM_Counter.Data; 

public interface IActionStorage {
	Task<int> GetActionCount(DateTimeOffset since, DateTimeOffset until);
	Task Store(MyAction action);
}
