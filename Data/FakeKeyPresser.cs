namespace APM_Counter.Data; 

public class FakeKeyPresser : BackgroundService {
	private readonly IActionStorage _actionStorage;

	public FakeKeyPresser(IActionStorage actionStorage) => _actionStorage = actionStorage;

	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
		var random = new Random();
		while (!stoppingToken.IsCancellationRequested) {
			await Task.Delay(TimeSpan.FromSeconds(random.NextDouble()), stoppingToken);

			await _actionStorage.Store(new MyAction{ Timestamp = DateTimeOffset.Now});
		}
	}
}
