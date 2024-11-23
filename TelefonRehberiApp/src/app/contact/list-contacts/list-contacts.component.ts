import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/person.model';
import { ContactService } from '../../services/contact.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { ColDef } from 'ag-grid-community';

@Component({
  selector: 'app-list-contacts',
  templateUrl: './list-contacts.component.html',
  styleUrls: ['./list-contacts.component.css']
})
export class ListContactsComponent implements OnInit {
  public contacts: Person[] = [];
  public columnDefs: ColDef[] = [ // ColDef tipini kullanın
    { headerName: 'İsim', field: 'firstName', sortable: true, filter: true , sort: 'asc', flex: 1},
    { headerName: 'Soyisim', field: 'lastName', sortable: true, filter: true, flex: 1 },
    { headerName: 'Telefon Numarası', field: 'phoneNumber', sortable: true, filter: true, flex: 1 },
    { headerName: 'E-Mail', field: 'email', sortable: true, filter: true, flex: 2 },
    {
      headerName: 'İşlemler',
      cellRenderer: (params: any) => {
        return `
        <button class="btn" data-action="update" data-id="${params.data.id}" style="background-color:white; 
        border: 2px solid gray; padding:2px 10px; border-radius:8px" hover="oppacity:0.6">Düzenle</button>
        <button class="btn" data-action="delete" data-id="${params.data.id}" style="color: red; 
        background-color:white; border: 2px solid gray; padding:2px 10px; border-radius:8px">Sil</button>
      `;
      },
      flex: 1
    }
  ];
  
  constructor(private contactService: ContactService, private router: Router) {}

  ngOnInit(): void {  this.loadContacts(); }

  onCellClicked(event: any): void {
    const action = event.event.target.getAttribute('data-action');
    const id = event.event.target.getAttribute('data-id');
    
    if (action === 'update' && id) { this.updateContact(id);} 
    else if (action === 'delete' && id) { this.onDelete(id); }
  }
    
  loadContacts(): void {
    this.contactService.getContacts().subscribe({ 
      next: (data: Person[]) => { this.contacts = data; },
      error: (error: any) => { console.error('Veri yüklenirken bir hata oluştu:', error); }
    });
    
  }
  
  updateContact(id: string): void { this.router.navigateByUrl(`/update-contact/${id}`); }
  
  onDelete(id: string): void {
    if (confirm('Bu kişiyi silmek istediğinizden emin misiniz?')) {
      this.contactService.deleteContact(id).subscribe({
        next: () => {
          alert('Kişi başarıyla silindi!');
          this.loadContacts();
        },
        error: (err: HttpErrorResponse) => {
          console.error('Silme sırasında bir hata oluştu:', err.message, err.status, err.error);
          alert('Silme işlemi sırasında bir hata oluştu.');
        }
      });
    }
  }
} 
