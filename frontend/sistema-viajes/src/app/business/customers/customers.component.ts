import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CollaboratorService } from '../../../services/collaborator.service';
import { CommonModule } from '@angular/common';
import { Customer } from '../..//models/customer.model'
import { ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule]
})
export class CustomersComponent implements OnInit {
  collaboratorForm: FormGroup;

  constructor(private fb: FormBuilder,
    private collaboratorService: CollaboratorService,
  ) {
    this.collaboratorForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern("^[0-9]{4}-[0-9]{4}$")]],
    },
    );
  }
  ngOnInit(): void {
    
    this.collaboratorForm;
  }


  onSubmit(): void {
    if (this.collaboratorForm.valid) {
      const formData: Customer = this.collaboratorForm.value;
      console.log("Datos a enviar",formData);

      this.collaboratorService.createCollaborator(formData).subscribe({
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
