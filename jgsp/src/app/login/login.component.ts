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


  loginForm = this.fb.group({
    Username: ['', Validators.required],
    Password: ['', Validators.required]
  });
  
  constructor(private http:AuthHttpService, private router: Router,private fb: FormBuilder) { }


  ngOnInit() {
  }

  logout(){
    localStorage.jwt = undefined;
    localStorage.loggedUser = undefined;
  }

  login(){
    let korisnik: Korisnik = this.loginForm.value;
    this.http.logIn(korisnik.KorisnickoIme,korisnik.Lozinka).subscribe(temp => {
      if(temp == "uspesno")
      {
        console.log(temp);
        this.router.navigate(["/pocentna"])
      }
      else if(temp == "neuspesno")
      {
        console.log(temp);
        this.router.navigate(["/login"])
      }
    });
  }

}
