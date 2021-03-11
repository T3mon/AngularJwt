import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { error } from 'protractor';

@Component({
  selector: 'app-private-data',
  templateUrl: './private-data.component.html',
  styleUrls: ['./private-data.component.css']
})
export class PrivateDataComponent implements OnInit {
  public privateDataset: Array<string>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<string>>(baseUrl + 'PrivateData').subscribe(result => {
      this.privateDataset = result;
    },
      error => {
        console.log("privatedata: " + error);
      }
    );


  }

  ngOnInit() {
  }

}
