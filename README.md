# OpenWeatherMap-API - C# Library
### Overview
This library takes what the openweathermap "current" (https://openweathermap.org/current) and "onecall" (https://openweathermap.org/api/one-call-api) apis return in JSON, and converts it to C# objects for easy interaction with in C# projects.  It supports (most/all) of the returned data the APIs return in JSON.  Always check properties for null values.

### CurrentWeather Returned Data
- Base - OpenWeather internal parameter
- Clouds
  * All - Level of cloudiness (percentage of cloud cover?)
- Cod - OpenWeather internal parameter
- Coord
  * Longitude - Query location longitude
  * Latitude - Query location latitude
- ID - OpenWeather City ID
- Main
  * Current - Current temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Minimum - Minimum temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * GroundLevel - Returns atmospheric pressure on ground level, hPa, raw from openweather API
  * Maximum - Maximum temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * SeaLevel - Returns atmospheric pressure on sea level, hPa, raw from openweather API
- Name - City name
- Rain
  * 3h - Returns rain related data for the last 3 hours at query location (if available).
- Snow
  * 3h - Returns snow related data for the last 3 hours at query location (if available).
- Sys
  * Type - System related parameter, avoid usage
  * ID - Openweather API city identification int
  * Message - System related parameter, avoid usage
  * Country - Country code of given query location
  * Sunrise - Returns DateTime for sunrise converted from openweather API returned unix time.
  * Sunset - Returns DateTime for sunset converted from openweather API returned unix time.
- Visibility - Current visibility
- Weathers
  * ID - System related parameter, avoid usage
  * Main - Main description of the weather (IE rain, snow, etc.)
  * Description - Description of main parameter (heavy intensity rain, etc)
  * Icon - Weather icon ID
- Wind
  * Speed - Gives wind speed in raw values returned by openweathermap api, in meters per second or miles per hour
  * Direction - Returns DirectionEnum with details of direction of wind on basis of degree
  * Degree - Returns raw 360-oriented degree returned by openweathermap api
  * Gust - Returns speed of wind gusts in meters per second or miles per hour

### OneCall Returned Data
- Alerts
  * Description - Description of the alert
  * End - Date and time of the end of hte alert, UTC
  * Event - Alert event name
  * SenderName - Name of the alert source
  * Start - Date and time of the start of the alert, UTC
- Current
  * Clouds - Cloudiness percentage
  * DewPoint - Atmospheric temperature below which water droplets begin to condense and dew can form. (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * DateTime - Current time, UTC
  * FeelsLike - Current "feels-like" temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Humidity - Percent humidity
  * Pressure - Atmospheric pressure, hPa
  * Sunrise - Sunrise time, UTC
  * Sunset - Sunset time, UTC
  * Temperature - Temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Uvi - Current UV index
  * Visibility - Current visibility
  * Weathers
    + ID - System related parameter, avoid usage
    + Main - Main description of the weather (IE rain, snow, etc.)
    + Description - Description of main parameter (heavy intensity rain, etc)
    + Icon - Weather icon ID
  * Wind
    + Speed - Gives wind speed in raw values returned by openweathermap api (Units – standard and metric: meters/second, imperial: miles/hour)
    + Direction - Returns DirectionEnum with details of direction of wind on basis of degree
    + Degree - Returns raw 360-oriented degree returned by openweathermap api
    + Gust - Returns speed of wind gusts (Units – standard and metric: meters/second, imperial: miles/hour)
- Daily
  * Clouds - Cloudiness percentage
  * DewPoint - Atmospheric temperature below which water droplets begin to condense and dew can form. (Units – default: kelvin, metric: Celsius, imperial: Fahrenheit)
  * DateTime - Date of the forecast data, UTC
  * FeelsLike
    + Day - Daytime temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Night - Nighttime temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Evening - Evening temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Morning - Morning temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Humidity - Percent humidity
  * Pop - Probability of precipitation
  * Pressure - Atmospheric pressure, hPa
  * Sunrise - Sunrise time, UTC
  * Sunset - Sunset time, UTC
  * Temp
    + Day - Day temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Minimum - Minimum temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Maximum - Maximum temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Night - Night temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Evening - Evening temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
    + Morning - Morning temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Uvi - Current UV index
  * Weathers
    + ID - System related parameter, avoid usage
    + Main - Main description of the weather (IE rain, snow, etc.)
    + Description - Description of main parameter (heavy intensity rain, etc)
    + Icon - Weather icon ID
  * Wind
    + Speed - Gives wind speed in raw values returned by openweathermap api (Units – standard and metric: meters/second, imperial: miles/hour)
    + Direction - Returns DirectionEnum with details of direction of wind on basis of degree
    + Degree - Returns raw 360-oriented degree returned by openweathermap api
    + Gust - Returns speed of wind gusts (Units – standard and metric: meters/second, imperial: miles/hour)
- Hourly
  * Clouds - Cloudiness percentage
  * DewPoint - Atmospheric temperature below which water droplets begin to condense and dew can form. (Units – default: kelvin, metric: Celsius, imperial: Fahrenheit)
  * DateTime - Time of the forecast data, UTC
  * FeelsLike - Current "feels-like" temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Humidity - Percent humidity
  * Pop - Probability of precipitation
  * Pressure - Atmospheric pressure, hPa
  * Temperature - Temperature (Units – standard: kelvin, metric: Celsius, imperial: Fahrenheit)
  * Uvi - Current UV index
  * Visibility - Current visibility
  * Weathers
    + ID - System related parameter, avoid usage
    + Main - Main description of the weather (IE rain, snow, etc.)
    + Description - Description of main parameter (heavy intensity rain, etc)
    + Icon - Weather icon ID
  * Wind
    + Speed - Gives wind speed in raw values returned by openweathermap api (Units – standard and metric: meters/second, imperial: miles/hour)
    + Direction - Returns DirectionEnum with details of direction of wind on basis of degree
    + Degree - Returns raw 360-oriented degree returned by openweathermap api
    + Gust - Returns speed of wind gusts (Units – standard and metric: meters/second, imperial: miles/hour)
- Longitude - Query location longitude
- Latitude - Query location latitude
- Minutely
  + DateTime - Time of the forecast data, UTC
  + Precipitation - Precipitation volume (Units – standard and metric: millimeters, imperial: inches)
- Timezone - Timezone name of the forecast location
- TimezoneOffset - Timezone shift from UTC, in seconds

### Added Functionality
- The openweathermap APIs return just Kelvin temperatures; this library include Celcius and Fahrenheit values.
- DirectionEnum - Added direction enum in Wind class that is set in constructor on the basis of degree double
- directionEnumToString(DirectionEnum dir) - Returns string value of wind direction on the basis of passed in DirectionEnum

### Installing
1. Clone this code
   - `git clone https://github.com/mlichtenberg/OpenWeatherMap-API-CSharp.git`
2. Open the code in VS
3. Build the code base
4. In your project that's using this code, reference the built DLL from the previous step:
   - Project dropdown -> Add Reference -> Search for the created DLL(s) file.
   - Generally, the path is something like: `/OpenWeatherMap-API-CSharp/bin/Debug/OpenWeatherAPI.dll`
   - You may also need to reference the `Newtonsoft.Json.dll` if you aren't already using this library.

### Example Usage
```csharp
var openWeatherAPI = new OpenWeatherAPI.API("my open weather api key");
var current = openWeatherAPI.CurrentWeather("city/location query", OpenWeatherAPI.UnitsEnum.Imperial);
Console.WriteLine(string.Format("The temperature in {0}, {1} is currently {2} °F", current.Name,current.Sys.Country, current.Main.Temperature.Current));
```

### Sample Project
This repository also has a sample project. Find it here: https://github.com/mlichtenberg/OpenWeatherMap-API-CSharp/tree/master/OpenWeatherAPI%20Example

### Credits and Libraries Utilized
- Newtonsoft.Json - JSON parsing class. 

### License
The MIT License (MIT)

Copyright (c) 2021 mlichtenberg

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
