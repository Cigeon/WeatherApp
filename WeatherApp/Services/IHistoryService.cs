using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IHistoryService
    {
        void SaveForecast(WeatherForecast forecast);
    }
}
