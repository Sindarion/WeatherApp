import { Component } from '@angular/core';
import { WeatherForecast } from './weather-model';

@Component({
  selector: 'app-weather',
  imports: [],
  templateUrl: './weather.html',
  styleUrl: './weather.scss'
})
export class Weather {

  forecastList: WeatherForecast[] = [];

  public fetchForecast() {
    const basePath = window.location.pathname;

    fetch(`${basePath}api/WeatherForecast`)
      .then(response => response.json())
      .then(data => {
        this.forecastList = data;
      });
  }
}
