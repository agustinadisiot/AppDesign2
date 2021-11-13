import { HttpErrorResponse } from "@angular/common/http";
import { throwError } from "rxjs";

export class Display {

  public static displayIsActiveAsResolve(value: boolean) {
    return value ? "Unresolved" : "Resolved"
  }

  public static displayStringNull(value: string) {
    return value == null ? "-" : value
  }
}