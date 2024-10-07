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
    // Verifica si el usuario está autenticado
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
          this.router.navigate(['/home']); // Redirige a home si no tiene autorización
          this.showUnauthorizedMessage(); 
          return false; 
        }
      }
      return false;
    } else {
      // Si no está autenticado, redirige a /login
      this.router.navigate(['/login']);
      return false;
    }
  }

  // Muestra un mensaje de no autorizado
  private showUnauthorizedMessage(): void {
    // Puedes usar un servicio de notificaciones, pero aquí usamos alert como ejemplo
    alert('No tienes autorización para acceder a esta página.');
  }
}
