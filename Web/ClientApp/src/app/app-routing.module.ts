import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FacturaComponent } from './factura/factura.component';
import { ImagenComponent } from './imagen/imagen.component';


const routes: Routes = [{
  path: 'factura',
  component: FacturaComponent},
  {
    path: 'imagen',
    component: ImagenComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
