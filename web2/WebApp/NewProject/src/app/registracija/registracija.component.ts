import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from '../services/http/auth.service';
import { Validators, FormBuilder } from '@angular/forms';
import { User } from '../folder/osoba';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {

  registacijaForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    username: ['', Validators.required],
    password: ['', Validators.required],
    confirmPassword: ['', Validators.required],
    email: ['', Validators.required],
    date: ['', Validators.required]
  });

  constructor(private http: AuthHttpService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
  }

  register(){
    let regModel: User = this.registacijaForm.value;
    this.http.registration(regModel);
    //form.reset();
  }

}
