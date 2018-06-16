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
  sort = 0;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.get();
  }

  changeSort() {
    this.sort = this.sort == 1 ? 0 : 1;
    this.get();
  }

  get() {
    this.http.get(`/api/Values?sort=${this.sort}`).subscribe(result => {
      this.result = result;
    }, error => {
      this.error = error;
    })
  }
}
