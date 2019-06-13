import { Component, OnInit } from '@angular/core';
import { TimetableInfo, TimetableType, Day, Line, Timetable } from '../model';

@Component({
  selector: 'app-redvoznjeedit',
  templateUrl: './redvoznjeedit.component.html',
  styleUrls: ['./redvoznjeedit.component.css']
})
export class RedvoznjeeditComponent implements OnInit {

  timetableInfo:TimetableInfo = new TimetableInfo();
  selectedTimetableType: TimetableType = new TimetableType();
  selectedDay: Day = new Day();
  selectedLine: Line = new Line();
  filteredLines: Line[] = [];
  timetable: Timetable = new Timetable();
  constructor() { }

  ngOnInit() {
  }

}
