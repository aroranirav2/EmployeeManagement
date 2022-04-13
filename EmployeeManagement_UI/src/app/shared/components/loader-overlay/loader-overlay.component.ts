import { Component } from '@angular/core';
import { LoaderOverlayService } from '../../services/loader-overlay.service';

@Component({
  selector: 'app-loader-overlay',
  templateUrl: './loader-overlay.component.html',
  styleUrls: ['./loader-overlay.component.scss']
})
export class LoaderOverlayComponent {
  constructor(private loaderOverLayService: LoaderOverlayService) { }

  get isLoaderVisible(): boolean {
    return this.loaderOverLayService.isLoaderVisible;
  }
}
