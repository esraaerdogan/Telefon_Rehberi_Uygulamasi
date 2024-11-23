import { Component, OnDestroy } from '@angular/core';
import { AddPersonRequest } from '../../models/add-person-request.model';
import { ContactService } from '../../services/contact.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CapitalizePipe } from '../../capitalize.pipe';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrl: './add-contact.component.css',
  providers: [CapitalizePipe]
})
export class AddContactComponent implements OnDestroy {

  model:AddPersonRequest;
  private addPersonSubscription?:Subscription;
  errorMessage?: string; // Hata mesajı için özellik

  constructor(private capitalizePipe: CapitalizePipe, private contactService:ContactService,
    private router:Router) {
    this.model = {
      FirstName:'',
      LastName:'',
      PhoneNumber: '',
      Email: ''
    };
  }

  onFormSubmit (contactForm: NgForm){
    if (contactForm.valid) {
      this.addPersonSubscription = this.contactService.addContact(this.model).subscribe({
        next: (response) => {
          window.alert('Kişi başarıyla eklendi!');
          setTimeout(() => {
            this.router.navigateByUrl('/');
          }, 100);
        },
        error: (error) => {
          if (error.status === 400) {
            this.errorMessage = error.error; // Hata mesajını göstermek için
          } else {
            console.error('Hata oluştu:', error);
          }
        }
      });
    }  
    else{
      this.errorMessage = 'Form geçersiz. Lütfen tüm alanları kontrol edin.';
    }
  }
  
  ngOnDestroy(): void {
    this.addPersonSubscription?.unsubscribe();
  }

  onFirstNameChange(value: string): void {
    this.model.FirstName = this.capitalizePipe.transform(value);
  }

  onLastNameChange(value: string): void {
    this.model.LastName = this.capitalizePipe.transform(value);
  }
}