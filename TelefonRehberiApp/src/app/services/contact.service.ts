import { Injectable } from '@angular/core';
import { AddPersonRequest } from '../models/add-person-request.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Person } from '../models/person.model';
import { UpdatePersonRequest } from '../models/update-person-request.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Person[]> { 
    return this.http.get<Person[]>(this.apiUrl);
  }

  getContactById(id: string): Observable<Person> {
    return this.http.get<Person>(`${this.apiUrl}/${id}`);
  }

  addContact(contact: AddPersonRequest): Observable<Person> {
    return this.http.post<Person>(this.apiUrl, contact);
  }

  updateContact(id: string, contact: UpdatePersonRequest): Observable<Person> {
    return this.http.put<Person>(`${this.apiUrl}/${id}`, contact);
  }

  deleteContact(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
