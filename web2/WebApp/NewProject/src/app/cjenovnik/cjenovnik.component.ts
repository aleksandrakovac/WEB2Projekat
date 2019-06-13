import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from '../services/http/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cjenovnik',
  templateUrl: './cjenovnik.component.html',
  styleUrls: ['./cjenovnik.component.css']
})
export class CjenovnikComponent implements OnInit {

  tipovi: string[] = ["Dnevna", "Mesecna", "Godisnja", "Vremenska"];
  korisnici: string[] = ["student", "penzioner", "regularni putnik"];
  korisnik: string;
  tip: string;
  cijena1: number;
  user:string;
  newPrice: number;
  ticketType:string;
  id1:number;
  constructor(private http: AuthHttpService) { }

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
  }

  Add()
  {
    this.http.GetAddPricelist(this.ticketType,this.newPrice).subscribe();
  }
  Delete()
  {
    this.http.GetDeletePricelist(this.id1).subscribe();
  }

  TicketPrice(){
    this.http.GetTicketPrice2(this.tip,this.korisnik).subscribe((cijena)=>{
      this.cijena1 = cijena;
      err => console.log(err);
    });
  }

  NewTicketPrice(ticketType:string,newPrice:number,form: NgForm){
    this.http.GetChangePrice(this.ticketType, this.newPrice).subscribe();   
  }

}
