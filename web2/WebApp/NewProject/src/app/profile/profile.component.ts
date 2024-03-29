import { Component, OnInit } from '@angular/core';
import { User } from '../folder/osoba';
import { Validators, FormBuilder } from '@angular/forms';
import { AuthHttpService } from '../services/http/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

    user: string;
    korisnik: User;
    korisnici: string[] = ["student", "penzioner", "regularni putnik"];
    registacijaForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      email: ['', Validators.required],
      date: ['', Validators.required],
      tip: ['', Validators.required]

    });
    
    FirstName: string;
    LastName: string;
    UserName: string;
    Password: string;
    ConfirmPassword: string;
    Email: string;
    Date: string;
    Tip:string;
    Podaci: User;

    constructor( private fb: FormBuilder,private http: AuthHttpService) { }


    ngOnInit() {
      let jwtData = localStorage.jwt.split('.')[1]
      this.FirstName =" korisnik.firstName";
      if(jwtData == undefined)
      {
        this.user = "neregistrovan";
      }
      else
      {
        let decodedJwtJsonData = window.atob(jwtData)
        let decodedJwtData = JSON.parse(decodedJwtJsonData)
        this.user = decodedJwtData.nameid;
      }
        this.http.GetUser(this.user).subscribe((korisnik)=>{
        this.LastName = korisnik.LastName;
        this.UserName = korisnik.UserName;
        this.Password = korisnik.Password;
        this.Date = korisnik.Data;
        this.Tip = korisnik.Tip;
        this.FirstName =korisnik.FirstName;

        this.registacijaForm.patchValue({
          firstName : korisnik.FirstName,
          lastName : korisnik.LastName,
          username : korisnik.UserName,
          email : korisnik.Email,
          password : korisnik.Password,
          confirmPassword : korisnik.ConfirmPassword,
          date: korisnik.Date,
          tip: korisnik.Tip
        })
        err => console.log(err);
      });
  }

  edit() {
  let jwtData = localStorage.jwt.split('.')[1]
      this.FirstName =" korisnik.firstName";
      if(jwtData == undefined)
      {
        this.user = "neregistrovan";
      }
      else
      {
        let decodedJwtJsonData = window.atob(jwtData)
        let decodedJwtData = JSON.parse(decodedJwtJsonData)
        this.user = decodedJwtData.nameid;
      }
      let regModel: User = this.registacijaForm.value;
      this.http.edit(regModel,this.user);
  }

}


