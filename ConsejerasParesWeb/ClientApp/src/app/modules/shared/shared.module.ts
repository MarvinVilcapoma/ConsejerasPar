import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { HeaderComponent } from './components/header/header.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BackgroundLayoutComponent } from './components/background-layout/background-layout.component';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [
    SidenavComponent,
    HeaderComponent,
    BackgroundLayoutComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    RouterModule,
    MaterialModule,
  ],
  exports: [
    SidenavComponent,
    HeaderComponent,
    BackgroundLayoutComponent
  ]
})
export class SharedModule { }
