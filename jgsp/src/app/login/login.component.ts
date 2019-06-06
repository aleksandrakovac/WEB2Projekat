import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, Validators } from '@angular/forms';
import { AuthHttpService } from 'src/services/http/auth.service';
import { Router } from '@angular/router';
import { Korisnik } from '../models/korisnik';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
