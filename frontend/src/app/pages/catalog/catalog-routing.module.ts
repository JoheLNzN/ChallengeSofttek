import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard } from 'src/shared/guards/auth.guard';
import { UserRoleType } from 'src/shared/services/account.service';

import { CatalogIndexComponent } from './catalog-index/catalog-index.component';
import { CatalogComponent } from './catalog.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: CatalogComponent,
        children: [
          {
            path: 'index',
            component: CatalogIndexComponent,
            canActivate: [AuthGuard],
            data: { expectedRole: UserRoleType.DEFAULT }
          },
          { path: '**', redirectTo: 'index' },
          { path: '', pathMatch: 'full', redirectTo: 'index' },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class CatalogRoutingModule {}
