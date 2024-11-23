import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LogEntry } from '../models/log-entry.model';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  private apiUrl = 'https://localhost:7059/api/Log'; // API endpointi

  constructor(private http: HttpClient) {}

  getLogs(): Observable<LogEntry[]> {
    return this.http.get<LogEntry[]>(this.apiUrl);
  }
}
