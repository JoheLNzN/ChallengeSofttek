import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServiceModule } from 'src/shared/services/service.module';

import { AuthGuard } from '../../../shared/guards/auth.guard';
import { CreateArticleComponent } from './create-article/create-article.component';
import { DashboardIndexComponent } from './dashboard-index/dashboard-index.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

@NgModule({
  declarations: [
    DashboardComponent,
    DashboardIndexComponent,
    CreateArticleComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ServiceModule
  ],
  providers: [
    AuthGuard
  ]
})
export class DashboardModule { }
