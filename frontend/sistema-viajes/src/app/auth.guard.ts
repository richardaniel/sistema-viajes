import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private apiService: ApiService, private router: Router) {}

  canActivate(): boolean {
  
    if (this.apiService.isLoggedIn()) {
      // Si el usuario está autenticado, obtenemos el token
      const token = this.apiService.getToken();
     
      if (token) {
        // Decodifica el token JWT para obtener el rol
        const decodedToken: any = jwtDecode(token);
        const role = decodedToken['role'];
        
        if (role === 'Gerente de Tienda') {
          console.log(role)
          return true; 
        } else {
          console.log(role)
          this.router.navigate(['/home']); 
          this.showUnauthorizedMessage(); 
          return false; 
        }
      }
     return true
    } else {
      this.router.navigate(['/login']);
      return false;
    }
  }
  private showUnauthorizedMessage(): void {
    
    alert('No tienes autorización para acceder a esta página.');
  }
}
