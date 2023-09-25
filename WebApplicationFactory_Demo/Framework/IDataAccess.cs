namespace Domain.Interfaces.DataAccess
{
    public interface IJadCentralDataAccess
    {
        string GetJadCentralConnectionString();

        Task<List<T>> ExecuteSPAsync<T>(string spName, object spParams, int? timeout = null);

        Task<T> ExecuteValueSPAsync<T>(string spName, object spParams, int? timeout = null);

        Task<List<dynamic>> ExecuteSPAsync(string spName, object spParams, int? timeout = null);

        Task<List<T>> ExecuteSPAsync<T>(string spName, object spParams, int? commandTimeout, Type[] types, Func<object[], T> mappingFunc, string splitOn);
    }
}