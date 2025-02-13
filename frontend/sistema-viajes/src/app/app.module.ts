import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterOutlet,RouterModule } from '@angular/router';
import { AppComponent } from './app.component';




@NgModule({
  declarations: [
    AppComponent,
    

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
    RouterOutlet,
    RouterModule,
    BrowserAnimationsModule
  ],
  providers: [
    provideClientHydration()
  ],
  
  bootstrap: [AppComponent]

})
export class AppModule { }



