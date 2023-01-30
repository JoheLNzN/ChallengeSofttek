import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

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
          { path: 'index', component: DashboardIndexComponent },
          { path: 'create-article', component: CreateArticleComponent },
          { path: '**', redirectTo: 'index' },
          { path: '', pathMatch: 'full', redirectTo: 'index' },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
