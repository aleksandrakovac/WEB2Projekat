import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { logging } from 'protractor';
import { User } from 'src/app/folder/osoba';


@Injectable()
export class AuthHttpService{

        base_url = "http://localhost:52295"
        user:string;

        constructor(private http: HttpClient){

        }

        logIn(username: string, password: string): Observable<boolean> | boolean{
            let isDone: boolean = false;
            let data = `username=${username}&password=${password}&grant_type=password`;
            let httpOptions = {
                headers: {
                    "Content-type": "application/x-www-form-urlencoded"
                }
            }
    
            this.http.post<any>(this.base_url + "/oauth/token", data, httpOptions).subscribe(data => {
                localStorage.jwt = data.access_token;
                let jwtData = localStorage.jwt.split('.')[1]
                let decodedJwtJsonData = window.atob(jwtData)
                let decodedJwtData = JSON.parse(decodedJwtJsonData)
    
      
                let role = decodedJwtData.role
                this.user = decodedJwtData.unique_name;
            });
    
            if(localStorage.jwt != "undefined"){
                isDone = true;
            }
            else{
                isDone = false;
            }
    
            return isDone;
            
        }
    

        /*logIn(username: string, password: string){

            let data = `username=${username}&password=${password}&grant_type=password`;
            let httpOptions = {
                headers:{
                    
                    "content-type": "application/x-www-form-urlencoded",

                

                }
            }
            this.http.post<any>(this.base_url + "/oauth/token",data, httpOptions )
            .subscribe(data => {
                localStorage.jwt = data.access_token;
                //let jwtData = localStorage.jwt.split('.')[1]
                //let decodedJwtJsonData = window.atob(jwtData)
                //let decodedJwtData = JSON.parse(decodedJwtJsonData) 

                //let role = decodedJwtData.role
                //this.user = decodedJwtData.unique_name;
            });
            

        }*/

       /* logIn2(username: string, password: string){

            this.http.get<any>(this.base_url + "/api/Account/GetTipKorisnika/" + username).subscribe();
       }*/  

        registration(data:User)
        {
             return this.http.post<any>(this.base_url + "/api/Account/Register", data).subscribe();
            
        }

        GetCenaKarte(tip: string): Observable<any>{
            return this.http.get<any>(this.base_url + "/api/TicketPrice/GetKarta/" + tip);
        }
        GetKupiKartu(tipKarte: string, tipKorisnika: string, user : string): Observable<any>{
           
            return this.http.get<any>(this.base_url + "/api/TicketPrice/GetKartaKupi2/" + tipKarte + "/" + tipKorisnika + "/" + user);
        }

        GetAllLines() : Observable<any>{
            return Observable.create((observer) => {
                this.http.get<any>(this.base_url + "/api/Lines/GetLinije").subscribe(data =>{
                    observer.next(data);
                    observer.complete();
                }) 
            });
        }
        GetTipKorisnika(user : string): Observable<any>{
           
            return this.http.get<any>(this.base_url + "/api/Account/GetTipKorisnika/" + user);
        }

}