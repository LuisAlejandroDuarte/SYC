import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FacturaComponent } from './factura/factura.component';
import { FacturaService } from './service/factura/service.factura';
import { HttpClientModule } from '@angular/common/http';
import { ImagenComponent } from './imagen/imagen.component';
import { ShowimagenComponent } from './showimagen/showimagen.component';

@NgModule({
  declarations: [
    AppComponent,
    FacturaComponent,
    ImagenComponent,
    ShowimagenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [FacturaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
