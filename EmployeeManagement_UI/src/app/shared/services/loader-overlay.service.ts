import { OverlayRef, Overlay } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { defer, finalize, NEVER, share } from 'rxjs';
import { LoaderOverlayComponent } from '../components/loader-overlay/loader-overlay.component';

@Injectable({
  providedIn: 'root'
})
export class LoaderOverlayService {
  private overlayRef: OverlayRef;
  isLoaderVisible: boolean;

  readonly spinner$ = defer(() => {
    this.show();
    return NEVER.pipe(
      finalize(() => {
        this.hide();
      })
    );
  }).pipe(share());

  constructor(private overlay: Overlay) { }

  show(): void {
    // Hack avoiding `ExpressionChangedAfterItHasBeenCheckedError` error
    Promise.resolve(null).then(() => {
      this.overlayRef = this.overlay.create({
        positionStrategy: this.overlay
          .position()
          .global()
          .centerHorizontally()
          .centerVertically(),
        hasBackdrop: true,
      });
      this.overlayRef.attach(new ComponentPortal(LoaderOverlayComponent));
    });
  }

  hide(): void {
    this.overlayRef.detach();
  }
}
