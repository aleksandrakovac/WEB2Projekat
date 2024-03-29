import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/services/http/auth.service';
import { NgForm } from '@angular/forms';
import { User } from '../folder/osoba';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(private http: AuthHttpService, public router: Router) { }

  ngOnInit() {
  }

  logIn(user:User,form: NgForm){
    let l =  this.http.logIn(user.username, user.password);
    //this.http.logIn2(user.username,user.password);
    //
    if(l){
      console.log("prijavljen");
    }
    this.router.navigate(["/home"]);
    //window.location.reload();
    //form.reset();

  }

}
