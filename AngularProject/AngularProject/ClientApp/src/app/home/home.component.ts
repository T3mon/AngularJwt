import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public settings: Settings
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Settings>(baseUrl + 'WeatherForecast/get-settings').subscribe(result => {
      this.settings = result;
    }, error => console.error(error));
  }
}

export class Settings {
  environmentSettings: EnvironmentSettings;
}
export class EnvironmentSettings {
  name: string;
}
