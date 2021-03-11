import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { NgForm } from '@angular/forms';
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private baseUrl: string;
  invalidLogin: boolean;
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') BaseUrl: string) {

  }

  ngOnInit() {
  }
  login(form: NgForm) {
    const payload = form.value;

    this.http.post(this.baseUrl + 'auth/login', payload).subscribe(result => {
      const token = (<any>result).token;
      localStorage.setItem('jwt', token);
      this.invalidLogin = false;
      this.router.navigate(['/private-data']);
    },
      err => {
        this.invalidLogin = true;
      }
    );
  }

}
