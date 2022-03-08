import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule  } from '@angular/platform-browser/animations';
import { PreloadFactory } from 'src/data/schemas/configuration/preLoadFactory';
import { ConfigLoaderService } from 'src/data/services/config-loader.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './modules/shared/shared.module';
// import { BackgroundLayoutComponent } from './modules/shared/components/background-layout/background-layout.component';


@NgModule({
  declarations: [
    AppComponent,
    // BackgroundLayoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [
    {provide: APP_INITIALIZER, deps: [ConfigLoaderService], multi: true, useFactory: PreloadFactory}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
