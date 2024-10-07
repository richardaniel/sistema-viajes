import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Branch } from '../../models/branch.model';
import { ApiService } from '../../../services/api.service';
import { Customer } from '../../models/customer.model';

@Component({
  selector: 'app-register-trip',
  templateUrl: './register-trip.component.html',
  standalone:true,
  imports: [CommonModule,ReactiveFormsModule]
})
export class RegisterTripComponent implements OnInit {
  branches: Branch[] = [];
  customers: Customer[] = []; 
  form: FormGroup;

  constructor(private fb: FormBuilder ,
    private Service: ApiService,
  ) {

    this.form = this.fb.group({
      customerId: ['', Validators.required],
      selectedCustomers: this.fb.array([])
    });
  }
  ngOnInit(): void {
    this.loadBranches();
  }

  loadBranches(): void {
    this.Service.getAllBranches().subscribe({
      next: (data) => {
        this.branches = data;
        console.log(data)
        
      },
      error: (error) => {
        console.error('Error fetching customers:', error);
      },
    });
  }

  onSucursalChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement; // Afirmación de tipo
    const branchId = selectElement.value; // Obtiene el valor del select
    this.Service.getCustomersByBranchId(branchId).subscribe({
      next: (data) => {
        this.customers = data; // Almacena los colaboradores
        console.log(data);
      },
      error: (error) => {
        console.error('Error fetching customers:', error);
      },
    });
  }

  onCustomerSelect(customerId: string, isChecked: boolean): void {
    
    const selectedCustomers = this.form.get('selectedCustomers') as FormArray;
    if (isChecked) {
      selectedCustomers.push(this.fb.control(customerId));
    } else {
      const index = selectedCustomers.controls.findIndex(control => control.value === customerId);
      selectedCustomers.removeAt(index);
    }
  }

  
}
