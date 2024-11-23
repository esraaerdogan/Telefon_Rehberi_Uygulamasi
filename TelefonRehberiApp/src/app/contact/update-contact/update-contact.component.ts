import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ContactService } from '../../services/contact.service';
import { Person } from '../../models/person.model';
import { UpdatePersonRequest } from '../../models/update-person-request.model';

@Component({
  selector: 'app-update-contact',
  templateUrl: './update-contact.component.html',
  styleUrl: './update-contact.component.css'
})
export class UpdateContactComponent implements OnInit,OnDestroy{

  id:string | null=null;
  paramsSubscriptions?:Subscription; 
  updatePersonSubscriptions?:Subscription; 
  person?:Person;
  formDirty = false;

  constructor(private route:ActivatedRoute, private contactservice:ContactService, 
    private router:Router){ }
 
  ngOnInit(): void {
    this.paramsSubscriptions =  this.route.paramMap.subscribe({
      next:(params)=>{ 
        this.id=params.get('id');
        if (this.id) { this.contactservice.getContactById(this.id).subscribe({
          next:(response)=>{ this.person=response; } });
        }}});
  }

  onFormSubmit(): void {
    const updatePersonRequest:UpdatePersonRequest={
      FirstName:this.person?.firstName ?? '',
      LastName:this.person?.lastName ?? '',
      PhoneNumber:this.person?.phoneNumber ?? '',
      Email:this.person?.email ?? ''
    };
    if (this.id){
      this.updatePersonSubscriptions= this.contactservice.updateContact(this.id,updatePersonRequest).subscribe({
        next:(response)=>{
          window.alert('Kişi başarıyla güncellendi!');
          this.router.navigateByUrl('/list-contacts')
        } }); }
  }    
  
  onDelete(): void {
    if (this.id) {
      this.contactservice.deleteContact(this.id).subscribe({
        next:(response)=>{
          window.alert('Kişi başarıyla silindi!');
          this.router.navigateByUrl('/list-contacts');
        }
      }); }      
  }

  onFormChange(): void {  this.formDirty = true; }

  onCancel(): void { this.router.navigateByUrl('/list-contacts');  }
    
  ngOnDestroy(): void {
    this.paramsSubscriptions?.unsubscribe();
    this.updatePersonSubscriptions?.unsubscribe();
  }
}
