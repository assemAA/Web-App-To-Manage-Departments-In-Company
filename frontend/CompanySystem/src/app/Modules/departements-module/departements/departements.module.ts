import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartementsListComponent } from './components/showDepartemensts/departements-list/departements-list.component';
import { HttpClientModule } from '@angular/common/http';
import { DepartementsService } from '../../../services/departements.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AddDepartementComponent } from './components/addDepartement/add-departement/add-departement.component'
import { AppRoutingModule } from '../../../app-routing.module';
import { EditDepartementComponent } from './components/editDepartement/edit-departement/edit-departement.component';



@NgModule({
  declarations: [
    DepartementsListComponent,
    AddDepartementComponent,
    EditDepartementComponent
  ],
  imports: [
    CommonModule , 
    HttpClientModule ,
    FormsModule ,
    ReactiveFormsModule ,
    AppRoutingModule
  ] ,
  providers: [DepartementsService],
  exports : [
    DepartementsListComponent
  ]
})
export class DepartementsModule { }
