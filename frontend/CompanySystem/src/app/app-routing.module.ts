import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule , Routes} from '@angular/router';
import { DepartementsListComponent } from './Modules/departements-module/departements/components/showDepartemensts/departements-list/departements-list.component';
import { AddDepartementComponent } from './Modules/departements-module/departements/components/addDepartement/add-departement/add-departement.component';
import { EditDepartementComponent } from './Modules/departements-module/departements/components/editDepartement/edit-departement/edit-departement.component';
import { HomeComponent } from './Components/Startups/Home/home/home.component';

const routes :Routes = [
  {path : 'departements' , component : DepartementsListComponent} , 
  {path : 'departements/new' , component : AddDepartementComponent} , 
  {path : 'departements/edit/:id' , component : EditDepartementComponent} ,
  {path : '' , component : HomeComponent}
]  ;



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes) ,
    RouterModule
  ] ,
  exports : [RouterModule]
})
export class AppRoutingModule { }
