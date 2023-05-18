import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router} from '@angular/router';
import { Departement } from 'src/app/models/Departement';
import { HttpClient } from '@angular/common/http';
import { DepartementsService } from '../../../../../../services/departements.service';

@Component({
  selector: 'app-add-departement',
  templateUrl: './add-departement.component.html',
  styleUrls: ['./add-departement.component.css']
})
export class AddDepartementComponent {

    constructor(private departementService : DepartementsService , private router :Router ){}
    
    departementForm = new FormGroup({
        departementName : new FormControl('', [Validators.required]) ,
        departementDescription : new FormControl('')
    })

    addDept(event : HTMLFormElement){

      if (this.validateForm()){
        event['preventDefault()'] 
        let departementName = this.getDepartementNameStatus.value
        let departementDescription = this.getDepartementDiscriptionStatus.value 
        let departementData = new Departement (0 , departementName ,departementDescription)
        
        this.departementService.addDepartement(departementData).subscribe( (res: any) => {})
  
        this.router.navigate([''])
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
