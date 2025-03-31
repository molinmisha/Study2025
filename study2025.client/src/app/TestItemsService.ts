import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

export interface TestItem {
  id: number;
  name: string;
  description: string;
  createdAt: Date;
}

@Injectable({
  providedIn: 'root'
})
export class TestDataService {
  private apiUrl = 'testitems';
  //private apiUrl = 'https://localhost:7158/testitems';
  //private apiUrl = 'https://localhost:54403/testitems';

  constructor(private http: HttpClient) { }

  getItems(): Observable<TestItem[]> {
    //return this.http.get<TestItem[]>(this.apiUrl);
    return this.http.get<TestItem[]>(environment.apiUrl + "/testitems"); 
  }
}
