export interface ButtonAction {
  text: string;
  color(element: any): "primary" | "accent" | "warn";
  onClick(element: any): void;
}