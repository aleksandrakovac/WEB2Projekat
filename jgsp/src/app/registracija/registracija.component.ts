import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/services/http/auth.service';
import { Router } from '@angular/router';
import { NgForm, FormBuilder, Validators } from '@angular/forms';
import { Korisnik } from '../models/korisnik';

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {

  registracijaForm = this.fb.group({
    Ime: ['', Validators.required],
    Prezime: ['', Validators.required],
    KorisnickoIme: ['', Validators.required],
    Email: ['', Validators.required],
    Lozinka: ['', Validators.required],
    PotvrdaLozinke: ['', Validators.required],
    Adresa: ['', Validators.required],
    Datum: ['', Validators.required],
  });

  constructor(private http:AuthHttpService, private router: Router, private fb: FormBuilder) { }
  
  ngOnInit() {
  }

  registracija()
  {
    let registracijaModel: Korisnik = this.registracijaForm.value;
    this.http.register(registracijaModel).subscribe(temp => {
      if(temp == "uspijesno")
      {
        console.log(temp);
        this.router.navigate(["/pocetna"]);
      }
      else if(temp == "neuspijesno")
      {
        console.log(temp);
        this.router.navigate(["/login"]);
      }
    })
  }

}
