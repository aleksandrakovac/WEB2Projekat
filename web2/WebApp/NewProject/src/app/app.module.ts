import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes} from '@angular/router'

import { HttpService } from '../app/services/http.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule} from '@angular/common/http'
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from 'src/app/interceptors/token.interceptors';
import { HomeComponent } from './home/home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { LoginComponent } from './login/login.component';
import { FolderComponent } from './folder/folder.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { AuthHttpService } from 'src/app/services/http/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { RedvoznjeComponent } from './redvoznje/redvoznje.component';
import { CjenovnikComponent } from './cjenovnik/cjenovnik.component';
import { KartaComponent } from './karta/karta.component';
import { LinijeComponent } from './linije/linije.component';

const routes : Routes = [
  {path:"home", component: HomeComponent},
  {path:"login", component: LoginComponent},
  

  {path: "", component: HomeComponent, pathMatch: "full"},
  {path: "**", redirectTo: "home"}
]
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent,
    LoginComponent,
    FolderComponent,
    RegistracijaComponent,
    RedvoznjeComponent,
    CjenovnikComponent,
    KartaComponent,
    LinijeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [HttpService, {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true},AuthHttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
