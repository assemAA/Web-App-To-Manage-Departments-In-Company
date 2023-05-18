import { Component, OnInit } from '@angular/core';
import { DepartementsService } from '../../../../../../services/departements.service';
import { Departement } from '../../../../../../models/Departement';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-departements-list',
  templateUrl: './departements-list.component.html',
  styleUrls: ['./departements-list.component.css']
})
export class DepartementsListComponent implements OnInit {

 

  public departements : Departement[] = []


  constructor(private departementService : DepartementsService){}

  ngOnInit(): void {
    this.departementService.getAllDepartements().subscribe( 
      (depts : Departement[] )=> this.departements = depts
       )
  }


  deleteProd(id : number){
    this.departementService.deleteDepartement(id).subscribe((res:any) => {})
    this.departements = this.departements.filter((ele)=>{
      return ele.id != id 
    })
  }

}
