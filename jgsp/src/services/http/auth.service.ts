import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Korisnik } from 'src/app/models/korisnik';

@Injectable()
export class AuthHttpService{
    base_url = "http://localhost:52295"
    constructor(private http: HttpClient){

    }

    logIn(korisnickoIme: string, lozinka: string) : Observable<any>{

        return Observable.create((observer) => {

            let data = `korisnickoIme=${korisnickoIme}&lozinka=${lozinka}&grant_type=lozinka`;
            let httpOptions={
                headers:{
                    "Content-type": "application/x-www-form-urlencoded"
                }
            }
            this.http.post<any>(this.base_url + "/oauth/token",data,httpOptions).subscribe(data => {

                localStorage.jwt = data.access_token;

                let jwtData = localStorage.jwt.split('.')[1]
                let decodedJwtJsonData = window.atob(jwtData)
                let decodedJwtData = JSON.parse(localStorage.decodedJwtJsonData)
        
                let role = decodedJwtData.role
        
                console.log('jwtData: ' + jwtData)
                console.log('decodedJwtJsonData: ' + decodedJwtJsonData)
                console.log('decodedJwtData: ' + decodedJwtData)
                console.log('Role ' + role)

                observer.next("uspesno");
                localStorage.setItem("ulogovaniKorisnik",korisnickoIme);
                observer.complete();
            },
            err => {
                console.log(err);
                observer.next("neuspesno");
                observer.complete();
            });
        });
     
    }

    logOut(): Observable<any>{
        return Observable.create((observer) => {
            localStorage.setItem("ulogovaniKorisnik",undefined);
            localStorage.jwt = undefined;
        });
    }

    register(user: Korisnik) : Observable<any>{

        return Observable.create((observer) => {
            let data = user;
            let httpOptions={
                headers:{
                    "Content-type": "application/json"
                }
            }
            this.http.post<any>(this.base_url + "/api/Account/Register",data,httpOptions).subscribe(data => {
                observer.next("uspesno");
                observer.complete();
            },
            err => {
                console.log(err);
                observer.next("neuspesno");
                observer.complete();
            });
        });
     
    }
}