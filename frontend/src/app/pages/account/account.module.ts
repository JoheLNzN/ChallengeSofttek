import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ServiceModule } from 'src/shared/services/service.module';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [AccountComponent, LoginComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    ServiceModule,
  ],
  exports: [],
})
export class AccountModule {}
