import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { CollaboratorBranchService } from '../../../services/collaborator-branch.service';
import { Customer } from '../../models/customer.model';
import { CommonModule } from '@angular/common';
import { Branch } from '../../models/branch.model';
import { CustomerBranch } from '../..//models/customer-branch.model'
import { ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-assign-branch',
  templateUrl: './assign-branch.component.html',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule]
})
export class AssignBranchComponent implements OnInit {
  assignBranchForm: FormGroup;
  customers: Customer[] = [];
  branches: Branch[] = [];

  constructor(private fb: FormBuilder,
    private collaboratorBranchService: CollaboratorBranchService,
    private Service: ApiService
  ) {
    this.assignBranchForm = this.fb.group({
      customerId: ['', Validators.required],
      branchId: ['', Validators.required],
      distanciaKm: ['', [Validators.required, Validators.min(1), Validators.max(50)]],
    },
    );
  } 
  ngOnInit(): void {
    this.loadCustomers();
    this.loadBranches();
    this.assignBranchForm;
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
  loadCustomers(): void {
    this.Service.getAllCustomers().subscribe({
      next: (data) => {
        

        this.customers = data;
      
        console.log(data)
        

      },
      error: (error) => {
        console.error('Error fetching customers:', error);
      },
      
    });
    
  }
  onSubmit(): void {
    if (this.assignBranchForm.valid) {
      const formData: CustomerBranch = this.assignBranchForm.value;


      
      console.log("Datos a enviar",formData);
      this.collaboratorBranchService.createCollaboratorBranch(formData).subscribe({
        next: (response) => {
          console.log('Colaborador asignado correctamente', response)
        },
        error: (error) => {
          console.error('Error al asignar colaborador', error)
        },
      });
    }
  }
}
