import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterOutlet,RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { TripReportComponent } from './business/trip-report/trip-report.component';



@NgModule({
  declarations: [
    AppComponent,
    TripReportComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule, 
    HttpClientModule,
    ToastrModule.forRoot(
      {
        timeOut: 3000, // Duración de las notificaciones
        positionClass: 'toast-top-right', // Posición en pantalla
        preventDuplicates: true, // Evita notificaciones duplicadas
      }
    ), // Inicializar Toastr
    BrowserAnimationsModule,// Importar animacion
    RouterOutlet,
    RouterModule
  ],
  providers: [
    provideClientHydration()
  ],
  
  bootstrap: [AppComponent]

})
export class AppModule { }



