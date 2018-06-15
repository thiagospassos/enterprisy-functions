import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  result;
  error;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('/api/CrashAndLog').subscribe(result => {
      this.result = result;
    }, error => {
      this.error = error;
    })
  }
}
