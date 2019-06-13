import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from '../services/http/auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  user: string
  korisnik : string

  constructor(private http:AuthHttpService) { }

  ngOnInit() {

      let jwtData = localStorage.jwt.split('.')[1]
        //let decodedJwtJsonData = window.atob(jwtData)
        //let decodedJwtData = JSON.parse(decodedJwtJsonData)
        //this.user = decodedJwtData.nameid;
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
          this.http.GetUserRole(this.user).subscribe((korisnik)=>{
          this.korisnik = korisnik;
          err => console.log(err);
        });
  }

}
