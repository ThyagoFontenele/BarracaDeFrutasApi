import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { debounceTime } from "rxjs/operators";

export enum Status {
  Error,
  Success
}

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  private readonly opened$ = new Subject<void>();

  constructor() {
    this.opened$
      .pipe(debounceTime(3000))
      .subscribe(() => this.removeSnackBar());
  }

  open(message: string, status?: Status): void {
    this.removeSnackBar();
    this.createSnackBar(message, status);
    this.opened$.next();
  }

  private createSnackBar(message: string, status?: Status): void {
    const div = document.createElement('div');
    div.classList.add('snackBar');

    switch (status) {
      case Status.Error:
        div.classList.add('error');
        break;
      case Status.Error:
        div.classList.add('sucess');
        break;
    }

    div.textContent = message;
    document.querySelector('.content')?.appendChild(div);
  }

  private removeSnackBar():void {
    document.querySelector('.snackBar')?.remove();
  }
}
