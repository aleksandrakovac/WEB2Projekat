import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from '../services/http/auth.service';

@Component({
  selector: 'app-karta',
  templateUrl: './karta.component.html',
  styleUrls: ['./karta.component.css']
})
export class KartaComponent implements OnInit {

  constructor(private http: AuthHttpService) { }
  tipovi: string[] = ["Dnevna", "Mesecna", "Godisnja", "Vremenska"];
  tip: string;
  cijena1: number;
  vaziDo1: string;
  user: string;
  korisnik:string;
  type:string;

  ngOnInit() {

        let jwtData = localStorage.jwt.split('.')[1]
       
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
          this.http.GetUserType(this.user).subscribe((korisnik)=>{
          this.korisnik = korisnik;
          //this.user = korisnik;
          err => console.log(err);
          
        });
        this.http.GetKorisnikType(this.user).subscribe((type)=>{
          this.type = type;
          //this.user = korisnik;
          err => console.log(err);
        });

  }

  TicketPrice(){
      this.http.GetTicketPrice(this.tip).subscribe((cijena)=>{
        this.cijena1 = cijena;
        err => console.log(err);
      });
  }

  BuyTicket(){
    if(localStorage.jwt != "undefined")
    {
      let jwtData = localStorage.jwt.split('.')[1]
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)
  
      this.user = decodedJwtData.nameid;
    }
    this.http.GetBuyTicket(this.tip, this.type, this.user).subscribe((vaziDo) =>
    {
      this.vaziDo1 = vaziDo;
      err => console.log(err);
    });
  }


}
