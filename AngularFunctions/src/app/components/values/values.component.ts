import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-values',
  templateUrl: './values.component.html',
  styleUrls: ['./values.component.css']
})
export class ValuesComponent implements OnInit {

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
    this.http.get(`${environment.api_base_url}/api/Sample2/${this.sort}`).subscribe(result => {
      console.log(result);
      this.result = result;
    }, error => {
      console.log(error);
      this.error = error;
    })
  }

}
