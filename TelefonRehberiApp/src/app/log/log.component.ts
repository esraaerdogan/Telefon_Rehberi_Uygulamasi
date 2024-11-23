import { Component, OnInit } from '@angular/core';
import { LogService } from '../services/log.service';
import { LogEntry } from '../models/log-entry.model'; 

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {
  logs: LogEntry[] = [];

  constructor(private logService: LogService) {}

  ngOnInit(): void {
    this.loadLogs();
  }

  loadLogs(): void {
    this.logService.getLogs().subscribe(logs => {
      this.logs = logs;
    });
  }
}
