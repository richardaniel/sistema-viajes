import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-trip-report',
  templateUrl: './trip-report.component.html',
})
export class TripReportComponent {
  tripReportForm: FormGroup;
  viajes: any[] = []; // Cargar desde el servicio
  totalAPagar: number = 0;
transportistas: any;

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
