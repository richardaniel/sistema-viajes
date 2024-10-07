import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators , ReactiveFormsModule } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone:true,
  imports:[ReactiveFormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  errorMessage: string = ''; // Variable para almacenar el mensaje de error

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private toastr: ToastrService,
    private router: Router // Inyectar Router para redirigir después del login
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  onSubmit(): void {
    this.errorMessage = ''; // Resetear el mensaje de error al iniciar el envío
    if (this.loginForm.valid) {
      this.apiService.login(this.loginForm.value).subscribe({
        next: (response: any) => {
        
          this.apiService.setToken(response.token);
         
          this.toastr.success('Inicio de sesión exitoso', 'Éxito');

          
          // Redirigir al panel
          this.router.navigate(['/home']);
        },
        error: (error) => {
          
          this.errorMessage = error.error.message || 'Error al iniciar sesión'; // Guardar el mensaje de error
        },
      });
    } else {
      this.errorMessage = 'Por favor, completa todos los campos requeridos';
    }
  }
}
