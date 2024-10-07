import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard'; // Importar el guard

const routes: Routes = [
  // Ruta para login
  {path: 'login', loadComponent: () => import('./login/login.component').then(m=>m.LoginComponent)},
  {path: '', loadComponent: () => import('./login/login.component').then(m=>m.LoginComponent)},
  

  { 
    path: 'register', 
    loadComponent: () => import('./register/register.component').then(m=>m.RegisterComponent),
    
  },

  { 
    path:'home',
    loadComponent:()=>import('./shared/components/layout/layout.component').then(m=>m.LayoutComponent),
    

    children:[{
      path:'dashboard',
      loadComponent:()=>import('./business/dashboard/dashboard.component').then(m=>m.DashboardComponent),
      
    },
    {
      path:'register-collaborator_branch',
      loadComponent:()=>import('./business/assign-branch/assign-branch.component').then(m=>m.AssignBranchComponent),
      
    },
    {
      path:'register-trip',
      loadComponent:()=>import('./business/register-trip/register-trip.component').then(m=>m.RegisterTripComponent),
      canActivate:[AuthGuard]
    },
    {
      path:'collaborator',
      loadComponent:()=>import('./business/customers/customers.component').then(m=>m.CustomersComponent),
      
    },
    ]
   },

  

  // Redirección para rutas no válidas
  { path: '**', redirectTo: '/login' } // Redirigir a login si la ruta no coincide
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // Configuración de rutas
  exports: [RouterModule]
})
export class AppRoutingModule {}
