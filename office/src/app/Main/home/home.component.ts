import { compileDeclareInjectableFromMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,FormControl,Validators } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BrdigeService } from 'src/app/brdige.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private fb: FormBuilder,private service:BrdigeService,private modalService: NgbModal) { }
profile:any;
editForm:any;
closeResult = '';

obj:any;

  ngOnInit(): void {
    this.setFormControl();


    this.service.getData().subscribe(data => {
      this.obj = data;
    }) 
  }


  setFormControl(){
       this.profile = this.fb.group({
        name: [''],
        age:[],
        email:[''],
      });
      this.editForm = this.fb.group({
        id: [],
        name:[''],
        age:[],
        email:[],
      });
  }



  saveChanges(){
    const x = this.profile.value;
    this.service.onSave(x).subscribe(data=>{
      
      this.service.getData().subscribe(data => {
        this.obj = data;
      }) 
    });
    this.resetForm();
    
  }

  delData(id){
    this.service.delete(id).subscribe(data=>{

      this.service.getData().subscribe(data => {
        this.obj = data;
      });
    });
    
  }
  resetForm(){
    this.profile.reset();
  }

  Update(){
    let obj = this.editForm.value;
    console.log(obj.id);

    this.service.UpdateData(obj).subscribe(data => {
      this.editForm.reset();
      this.service.getData().subscribe(data => {
        this.obj = data;
      }) ;
    });
   
  }


  open(content,o) {
    
    const obj = Object.assign({}, this.editForm?.getRawValue(), o);
    this.editForm?.patchValue(obj);
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  

}
