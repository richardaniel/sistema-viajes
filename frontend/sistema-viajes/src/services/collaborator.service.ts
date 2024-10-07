import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerBranch } from '../app/models/customer-branch.model'
import { Customer } from '../app/models/customer.model';

@Injectable({
  providedIn: 'root',
})
export class CollaboratorService {
    private baseUrl: string = 'http://localhost:5258';

  constructor(private http: HttpClient) {}

  createCollaborator(data: Customer) {
    return this.http.post<any>(`${this.baseUrl}/customers`, data);
  }
}
