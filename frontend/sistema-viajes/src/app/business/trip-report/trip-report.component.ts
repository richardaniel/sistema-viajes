
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {  MatTableModule } from '@angular/material/table';
import { TripReport } from '../../models/trip-report';



@Component({
  standalone: true,
  imports:[CommonModule,MatTableModule],
  selector: 'app-trip-report',
  templateUrl: './trip-report.component.html',
})
export class TripReportComponent {
  tripReportForm: FormGroup;
  Trips : TripReport[]=[
    {
      id:'1',
      transporter:'Richard',
      cost:25,
      date:new Date()

    },{
      id:'1',
      transporter:'Richard',
      cost:25,
      date:new Date()

    },{
      id:'1',
      transporter:'Richard',
      cost:25,
      date:new Date()

    },{
      id:'1',
      transporter:'Richard',
      cost:25,
      date:new Date()

    },{
      id:'1',
      transporter:'Richard',
      cost:25,
      date:new Date()

    }
  ];
  displaycolumns:any[]=['Id','Transportista','Fecha','Costo'];

  constructor(private fb: FormBuilder) {
    this.tripReportForm = this.fb.group({
      transportista: [''],
      fechaDesde: [''],
      fechaHasta: [''],
    });
  }

  onSubmit() {
    const { transportista, fechaDesde, fechaHasta } = this.tripReportForm.value;
    // Lógica para filtrar y cargar los viajes según los criterios seleccionados
  }
}
