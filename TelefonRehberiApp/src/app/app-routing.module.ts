import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddContactComponent } from './contact/add-contact/add-contact.component';
import { ListContactsComponent } from './contact/list-contacts/list-contacts.component';
import { UpdateContactComponent } from './contact/update-contact/update-contact.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add-contact', component: AddContactComponent },
  { path: 'list-contacts', component: ListContactsComponent },
  { path: 'update-contact/:id', component: UpdateContactComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }