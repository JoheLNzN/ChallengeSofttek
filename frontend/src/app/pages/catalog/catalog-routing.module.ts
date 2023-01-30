import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CatalogIndexComponent } from './catalog-index/catalog-index.component';
import { CatalogComponent } from './catalog.component';


@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: CatalogComponent,
        children: [
          { path: 'index', component: CatalogIndexComponent },
          { path: '**', redirectTo: 'index' },
          { path: '', pathMatch: 'full', redirectTo: 'index' },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class CatalogRoutingModule {}
