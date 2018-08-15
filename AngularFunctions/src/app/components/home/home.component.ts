import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  people = [];
  error: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.http.get(`${environment.api_base_url}/api/GetPeople`).subscribe((result: any) => {
      this.people = result;
    }, error => {
      console.log(error);
      this.error = error;
    })
  }
}
