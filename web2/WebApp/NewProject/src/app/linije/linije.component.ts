import { Component, OnInit } from '@angular/core';
import { Line, Station } from '../model';
import { AuthHttpService } from '../services/http/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-linije',
  templateUrl: './linije.component.html',
  styleUrls: ['./linije.component.css']
})
export class LinijeComponent implements OnInit {

  lines:Line[]=[];
  stations: Station[]=[];
  user:string;
  line: Line;
  lineNumber: number;
  tip: string;
  tipovi: string[] = ["Gradski", "Prigradski"];
  
  constructor(private http:AuthHttpService) { }

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


    this.http.GetAllLines().subscribe((lines) => {
      this.lines = lines;
      err => console.log(err);
    });
    
  }
  EditLine(tispKarte:number,form: NgForm){
    this.http.GetEditLine(this.line.Number, this.lineNumber).subscribe();
  }

}

