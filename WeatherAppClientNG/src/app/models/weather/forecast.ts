import { City } from '../city';
import { Period } from '../period';

export class WeatherCity {
    Id: number;
    Name: string;
    Coord: Coord;
    Country: string;
    Population: number;
}

export class Coord {
    lon: number;
    lat: number;
}

export class List {
    Id: number;
    Dt: number;
    Temp: Temp;
    Pressure: number;
    Humidity: number;
    Weather: Weather[];
    Speed: number;
    Deg: number;
    Clouds: number;
    WeatherForecastId: number;
}

export class Temp {
    Day: number;
    Min: number;
    Max: number;
    Night: number;
    Eve: number;
    Morn: number;
}

export class Weather {
    WeatherId: number;
    Id: number;
    Main: string;
    Description: string;
    Icon: string;
    DailyForecastId: number;
}

export class Forecast {
    Id: number;
    Dt: string;
    City: WeatherCity;
    Cod: string;
    Message: number;
    Cnt: number;
    list: List[];
    ReqCity: City;
    ReqPeriod: Period;
}
