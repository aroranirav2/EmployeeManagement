import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private readonly snackBar: MatSnackBar) { }

  showSuccess(message: string, action?: string, duration?: number, className?: string): void {
    const timeDisplay = duration ? duration : 3000;
    const snackBarClass = className ? className : 'green-snackbar';
    const act = action ? action : '';
    this.openSnackBar(message, act, timeDisplay, snackBarClass);
  }

  showError(message: string, action?: string, duration?: number, className?: string): void {
    const timeDisplay = duration ? duration : 3000;
    const snackBarClass = className ? className : 'red-snackbar';
    const act = action ? action : '';
    this.openSnackBar(message, act, timeDisplay, snackBarClass);
  }

  openSnackBar(message: string, action: string, duration: number, className: string): void {
    this.snackBar.open(message, action, {
      duration: duration,
      panelClass: [className]
    })
  }

}
