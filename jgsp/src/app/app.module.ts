import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { RouterModule,Routes} from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { PocetnaComponent } from './pocetna/pocetna.component';
import { AuthHttpService } from 'src/services/http/auth.service';

const routes : Routes = [
  {path : "login", component: LoginComponent},
  {path : "pocetna", component: PocetnaComponent},
  {path : "", component: PocetnaComponent, pathMatch:"full"},
  {path : "**", redirectTo: "login"},
]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PocetnaComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes)  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
