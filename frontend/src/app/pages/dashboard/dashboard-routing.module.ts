import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AuthGuard } from '../../../shared/guards/auth.guard';
import { UserRoleType } from './../../../shared/services/account.service';
import { CreateArticleComponent } from './create-article/create-article.component';
import { DashboardIndexComponent } from './dashboard-index/dashboard-index.component';
import { DashboardComponent } from './dashboard.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: DashboardComponent,
        children: [
          {
            path: 'index',
            component: DashboardIndexComponent,
            canActivate: [AuthGuard],
            data: { expectedRole: UserRoleType.ADMIN },
          },
          {
            path: 'create-article',
            component: CreateArticleComponent,
            canActivate: [AuthGuard],
            data: { expectedRole: UserRoleType.ADMIN },
          },
          { path: '**', redirectTo: 'index' },
          { path: '', pathMatch: 'full', redirectTo: 'index' },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
