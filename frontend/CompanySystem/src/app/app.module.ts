import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/Startups/navbar/navbar.component';
import { DepartementsModule } from './Modules/departements-module/departements/departements.module';
import { DepartementsService } from './services/departements.service';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './Components/Startups/Home/home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent
    
  ],
  imports: [
    BrowserModule ,
    DepartementsModule ,
    HttpClientModule,
    AppRoutingModule , 
    RouterModule , 
  
  ],
  providers: [DepartementsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
