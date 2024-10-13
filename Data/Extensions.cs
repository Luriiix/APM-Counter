namespace APM_Counter.Data;

public static class Extensions {
	public static async Task<int> GetApm(this IActionStorage actionStorage) {
		var now = DateTimeOffset.Now;
		var since = now - TimeSpan.FromSeconds(60);
		return await actionStorage.GetActionCount(since, now);
	}
}
