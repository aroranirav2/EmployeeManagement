import { Injectable } from '@angular/core';
import { defer, finalize, NEVER, share, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  isLoaderVisible: boolean;
  loaderVisibilityChange: Subject<boolean> = new Subject<boolean>();

  readonly spinner$ = defer(() => {
    this.show();
    return NEVER.pipe(
      finalize(() => {
        this.hide();
      })
    );
  }).pipe(share());

  constructor() {
    this.loaderVisibilityChange.subscribe((visibility: boolean) => this.isLoaderVisible = visibility);
  }

  show(): void {
    // Hack avoiding `ExpressionChangedAfterItHasBeenCheckedError` error
    Promise.resolve(null).then(() => {
      this.loaderVisibilityChange.next(true);
    });
  }

  hide(): void {
    this.loaderVisibilityChange.next(false);
  }
}
