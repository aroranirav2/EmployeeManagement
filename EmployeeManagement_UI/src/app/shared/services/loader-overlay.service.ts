import { OverlayRef, Overlay } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { defer, finalize, NEVER, share, Subject } from 'rxjs';
import { LoaderOverlayComponent } from '../components/loader-overlay/loader-overlay.component';

@Injectable({
  providedIn: 'root'
})
export class LoaderOverlayService {
  // private overlayRef: OverlayRef;
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

  constructor(private overlay: Overlay) {
    this.loaderVisibilityChange.subscribe((visibility: boolean) => this.isLoaderVisible = visibility);
  }

  show(): void {
    // Hack avoiding `ExpressionChangedAfterItHasBeenCheckedError` error
    Promise.resolve(null).then(() => {
      // this.overlayRef = this.overlay.create({
      //   positionStrategy: this.overlay
      //     .position()
      //     .global()
      //     .centerHorizontally()
      //     .centerVertically(),
      //   hasBackdrop: true,
      // });
      // this.overlayRef.attach(new ComponentPortal(LoaderOverlayComponent));
      this.loaderVisibilityChange.next(true);
    });
  }

  hide(): void {
    // this.overlayRef.detach();
    this.loaderVisibilityChange.next(false);
  }
}
