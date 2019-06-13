import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthHttpService } from '../services/http/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checking',
  templateUrl: './checking.component.html',
  styleUrls: ['./checking.component.css']
})
export class CheckingComponent implements OnInit {

  private id:string;
  constructor(private http: AuthHttpService,public router: Router) { }


  ngOnInit() {
    
  }
  check(id : string,form: NgForm){
    this.http.check(this.id).subscribe();
  }

}
