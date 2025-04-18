import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TestDataService } from './TestItemsService';
import { environment } from '../environments/environment';
import { catchError, tap } from 'rxjs';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
 interface TestItem {
  id: number;
  name: string;
  description: string;
  createdAt: Date;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public testItems: TestItem[] = [];

  constructor(private http: HttpClient, private testDataService: TestDataService) {}

  ngOnInit() {
    this.getForecasts();

    //this.getTestItems();
    this.testDataService.getItems().subscribe(
      data => this.testItems = data,
      error => console.error('Error fetching items', error)
    );
  }


  getForecasts(): void {
    let apiUrl = environment.apiUrl + '/weatherforecast';

    this.http.get<WeatherForecast[]>(apiUrl).pipe(
      tap((result) => {
        this.forecasts = result;
      }),
      catchError((error) => {
        console.error(error);
        // Здесь вы можете вернуть другой Observable или выбросить ошибку дальше
        return []; // Пример: вернуть пустой массив, чтобы поток не сломался
      })
    ).subscribe(); // Подписываемся на пайпированный Observable
  }


  //getTestItems() {
  //  let apiUrl = '/testitems';

  //  this.http.get<TestItem[]>(apiUrl).subscribe(
  //    (result) => {
  //      this.testItems = result;
  //    },
  //    (error) => {
  //      console.error(error);
  //    }
  //  );
  //}

  title = 'study2025.client';
}
