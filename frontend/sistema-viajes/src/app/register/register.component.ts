import { Component,OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators , ReactiveFormsModule  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from '../../services/api.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  standalone:true,
  imports:[ReactiveFormsModule],
  styleUrl: './register.component.css',
  
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
     private http: HttpClient,
     private toastr: ToastrService,
     private apiService : ApiService
    ) {}

  ngOnInit():void{
    this.registerForm = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rol: ['', [Validators.required]],
    });
  }
  onSubmit(): void {
    if (this.registerForm.valid) {
      this.apiService.register(this.registerForm.value)
        .subscribe({
          next: (response) => {
            this.toastr.success('Usuario registrado con éxito', 'Éxito');
            console.log('Usuario registrado con éxito', response);
          },
          error: (error) => {
            this.toastr.error('Error al registrar el usuario: ' + error.error.message, 'Error');
            console.error('Error al registrar el usuario', error);
          },
        });
      } 
      else{
        this.toastr.warning('Por favor, completa todos los campos requeridos', 'Advertencia');
      }
    }
}
