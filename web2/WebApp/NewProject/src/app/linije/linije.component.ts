import { Component, OnInit } from '@angular/core';
import { Line, Station, TimetableInfo, TimetableType, Day, Timetable } from '../model';
import { AuthHttpService } from '../services/http/auth.service';
import { NgForm } from '@angular/forms';
import { RedVoznjeHttpService } from '../services/redvoznje.service';

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
  timetableInfo:TimetableInfo = new TimetableInfo();
  selectedTimetableType: TimetableType = new TimetableType();
  //selectedLine: Line = new Line();
  //timetable: Timetable = new Timetable();
  
  constructor(private http:AuthHttpService, private http2:RedVoznjeHttpService) { }

  ngOnInit() {
    /*this.http.GetAllLines().subscribe((lines) => {
      this.lines = lines;
      err => console.log(err);
    });*/
    this.http2.getAll().subscribe((timetableInfo) => {
      this.timetableInfo = timetableInfo;
      err => console.log(err);
    });

    /*let jwtData = localStorage.jwt.split('.')[1]
    if(jwtData == undefined)
    {
      this.user = "neregistrovan";
    }
    else
    {
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.parse(decodedJwtJsonData)
      this.user = decodedJwtData.nameid;
    }*/


    
    
  }/*
  EditLine(tispKarte:number,form: NgForm){
    this.http.GetEditLine(this.line.Number, this.lineNumber).subscribe();
  }*/

}

