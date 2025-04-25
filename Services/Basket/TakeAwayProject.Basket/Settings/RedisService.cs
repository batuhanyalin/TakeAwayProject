using StackExchange.Redis;

namespace TakeAwayProject.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }
        public ConnectionMultiplexer _connectionMultiplexer; //Redise bağlanmak için field oluşturuyoruz.
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect
            ($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
