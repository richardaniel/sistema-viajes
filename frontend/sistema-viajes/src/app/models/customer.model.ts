export interface Customer {
  customerId: {
    value: string; // El GUID que está dentro de la propiedad 'value'
  };
  name: string;
  lastName: string;
  fullName: string;
  email: string;
  phoneNumber: string | null; // Puede ser null si no hay número de teléfono
  active: boolean;
}