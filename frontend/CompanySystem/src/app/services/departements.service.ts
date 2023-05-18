import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient} from '@angular/common/http'
import { Departement } from '../models/Departement';
import { from, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class DepartementsService {

  baseUrl = "http://localhost:35212/";


  constructor(public httpClient : HttpClient) { }

  getAllDepartements():Observable<Departement[]>  {
    return this.httpClient.get<Departement[]>(this.baseUrl + 'api/Departement');
  }

  addDepartement(departement : Departement){
    return this.httpClient.post(this.baseUrl + 'api/Departement' , departement)
  }

  deleteDepartement(id : number){
    return this.httpClient.delete(this.baseUrl + 'api/Departement/' + id)
  }

  editDepartement(departement : Departement , id : number) {
    return this.httpClient.put(this.baseUrl + 'api/Departement/' + id , departement)
  }

  getDepartementById(id : number):Observable<any>{
    return this.httpClient.get(this.baseUrl + 'api/Departement/' + id )
  }
}
