import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AgGridModule } from 'ag-grid-angular';
import { LogService } from './services/log.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { ListContactsComponent } from './contact/list-contacts/list-contacts.component';
import { AddContactComponent } from './contact/add-contact/add-contact.component';
import { UpdateContactComponent } from './contact/update-contact/update-contact.component';
import { LogComponent } from './log/log.component';
import { CapitalizePipe } from './capitalize.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ListContactsComponent,
    AddContactComponent,
    UpdateContactComponent,
    LogComponent,
    CapitalizePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    AgGridModule
  ],
  providers: [LogService],
  bootstrap: [AppComponent]
})
export class AppModule { }