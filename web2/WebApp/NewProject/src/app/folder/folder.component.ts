import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';
import { ValuesHttpService } from 'src/app/services/http/valueshttp';
import { AuthHttpService } from 'src/app/services/http/auth.service';

@Component({
  selector: 'app-folder',
  templateUrl: './folder.component.html',
  styleUrls: ['./folder.component.css'],
  providers: [ValuesHttpService, AuthHttpService]

})
export class FolderComponent implements OnInit {

   name: string
  clicks: number
  values: string[]
  constructor(private http: ValuesHttpService, private auth: AuthHttpService) { }

  ngOnInit() {
    this.name = "folder";

    this.auth.logIn("admin@yahoo.com","Admin123!");
    this.http.getAll().subscribe((values) => this.values = values, err => console.log(err));
    this.clicks = 0;
  }  

  clickCounter(){
    this.clicks++;
  }

}
