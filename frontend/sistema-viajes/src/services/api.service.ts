import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service'; // Asegúrate de que la ruta sea correcta
import { Observable } from 'rxjs';
import { Customer } from '../app/models/customer.model';
import { Branch } from '../app/models/branch.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl: string = 'http://localhost:5258';

  constructor(private http: HttpClient, private storageService: StorageService) {}

  login(data: any) {
    return this.http.post(`${this.baseUrl}/api/auth/login`, data);
  }

  register(data: any) {
    return this.http.post(`${this.baseUrl}/api/auth/register`, data);
  }

  setToken(token: string): void {
    this.storageService.setItem('token', token);
  }

  getToken(): string | null {
    return this.storageService.getItem('token');
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

  logout(): void {
    this.storageService.removeItem('token');
  }
  getAllCustomers(): Observable<any> {
    return this.http.get<any[]>(`${this.baseUrl}/customers`);
  }

  getAllBranches():Observable<any>{
    return this.http.get<any[]>(`${this.baseUrl}/branches`);
  }

  getCustomersByBranchId(branchId: string): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.baseUrl}/branches/${branchId}/customers`);
  }
}
