import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';
import { LayoutModule } from '@angular/cdk/layout';
import { HeaderComponent } from './components/header/header.component';
import { MaterialModule } from './material.module';
import { SideNavBarComponent } from './components/side-nav-bar/side-nav-bar.component';
import { LoaderComponent } from './components/loader/loader.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    HeaderComponent,
    SideNavBarComponent,
    LoaderComponent
  ],
  imports: [
    AppRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    LayoutModule,
    MaterialModule
  ],
  exports: [
    HeaderComponent,
    SideNavBarComponent,
    LoaderComponent,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
