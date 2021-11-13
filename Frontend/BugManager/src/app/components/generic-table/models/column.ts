export interface Column {
  header: string;
  property: string;
  display(value: any): any
}