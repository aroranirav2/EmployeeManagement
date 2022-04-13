import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';
import { LayoutModule } from '@angular/cdk/layout';
import { HeaderComponent } from './components/header/header.component';
import { MaterialModule } from './material.module';
import { SideNavBarComponent } from './components/side-nav-bar/side-nav-bar.component';
import { LoaderComponent } from './components/loader/loader.component';

@NgModule({
  declarations: [
    HeaderComponent,
    SideNavBarComponent,
    LoaderComponent
  ],
  imports: [
    AppRoutingModule,
    CommonModule,
    LayoutModule,
    MaterialModule
  ],
  exports: [
    HeaderComponent,
    SideNavBarComponent,
    LoaderComponent
  ]
})
export class SharedModule { }
