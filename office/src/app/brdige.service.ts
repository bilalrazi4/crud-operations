import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from 'src/config/config';
import { compileDeclareInjectableFromMetadata } from '@angular/compiler';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Injectable({
  providedIn: 'root'
})
export class BrdigeService {

  constructor(private http:HttpClient) {}

  
  onSave(values:any){
   debugger;
    return this.http.post<any>(`${Config.Url()}/api/Employe`,values);
  }

  getData(){
    debugger;
    return this.http.get<any>(`${Config.Url()}/api/Employe`);
  }

  UpdateData(val){
    debugger;
    return this.http.put<any>(`${Config.Url()}/api/Employe/`+val.id,val);
  }

  delete(id){
    
    return this.http.delete<any>(`${Config.Url()}/api/Employe/`+id);
  }
}


