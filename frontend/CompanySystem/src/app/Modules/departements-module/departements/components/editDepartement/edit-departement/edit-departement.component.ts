import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Departement } from 'src/app/models/Departement';
import { HttpClient } from '@angular/common/http';
import { DepartementsService } from '../../../../../../services/departements.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-departement',
  templateUrl: './edit-departement.component.html',
  styleUrls: ['./edit-departement.component.css']
})
export class EditDepartementComponent implements OnInit {

  wantedDepartement : any
  deptId : number =0
  departementNameBeforeEdit : string = ""
  departementDescriptionBeforeEdit : string = ""


  constructor(private activeRouter: ActivatedRoute , private departementService : DepartementsService
    , private router : Router){

      this.deptId = this.activeRouter.snapshot.params['id'] ;
      
    }

 
  ngOnInit(): void {
    this.wantedDepartement = this.departementService.getDepartementById(this.deptId)
      .subscribe( (dept : any) => {
        this.wantedDepartement = dept 
        this.departementNameBeforeEdit = this.wantedDepartement.name;
        this.departementDescriptionBeforeEdit = this.wantedDepartement.description

      })
    
  }

  departementForm = new FormGroup({
    departementName : new FormControl('', [Validators.required]) ,
    departementDescription : new FormControl('')
})

addDept(event : HTMLFormElement){

  if (this.validateForm()){
    event['preventDefault()'] 
    let departementName = this.getDepartementNameStatus.value
    let departementDescription = this.getDepartementDiscriptionStatus.value 
    let departementData = new Departement (this.deptId , departementName ,departementDescription)
    
    this.departementService.editDepartement(departementData , this.deptId).subscribe( (res: any) => {})

    this.router.navigate(['/'])
  }
  

}

get getDepartementNameStatus(){
  return this.departementForm.controls['departementName']
}

get getDepartementDiscriptionStatus(){
  return this.departementForm.controls['departementDescription']

}


validateForm () {

  if (this.getDepartementNameStatus.errors == null && this.getDepartementDiscriptionStatus.errors == null ) 
    return true
  else 
    return false
  
}
    
}
