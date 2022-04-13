import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { finalize, Observable, Subscription } from 'rxjs';
import { LoaderOverlayService } from '../services/loader-overlay.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {

  constructor(private readonly loaderOverlayService: LoaderOverlayService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const loaderSubscription: Subscription = this.loaderOverlayService.spinner$.subscribe();
    return next.handle(request).pipe(finalize(() => loaderSubscription.unsubscribe()));
  }
}
