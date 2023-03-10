import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from 'src/shared/guards/auth.guard';
import { ServiceModule } from 'src/shared/services/service.module';

import { CatalogIndexComponent } from './catalog-index/catalog-index.component';
import { CatalogRoutingModule } from './catalog-routing.module';
import { CatalogComponent } from './catalog.component';

@NgModule({
  declarations: [CatalogComponent, CatalogIndexComponent],
  imports: [
    CommonModule,
    CatalogRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ServiceModule
  ],
  providers:[
    AuthGuard
  ]
})
export class CatalogModule {}
