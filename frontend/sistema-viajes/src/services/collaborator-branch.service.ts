import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerBranch } from '../app/models/customer-branch.model'

@Injectable({
  providedIn: 'root',
})
export class CollaboratorBranchService {
    private baseUrl: string = 'http://localhost:5258';

  constructor(private http: HttpClient) {}

  createCollaboratorBranch(data: CustomerBranch) {
    return this.http.post<any>(`${this.baseUrl}/collaboratorbranches`, data);
  }
}
