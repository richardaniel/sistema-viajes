export interface Customer {
  collaboratorId: {
    value: string; // El GUID que está dentro de la propiedad 'value'
  };
  name: string;
  lastName: string;
  fullName: string;
  email: string;
  phoneNumber: string | null; 
  active: boolean;
}