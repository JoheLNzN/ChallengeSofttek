import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'account',
    loadChildren: () =>
      import('./pages/account/account.module').then((m) => m.AccountModule),
    data: { preload: true },
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./pages/dashboard/dashboard.module').then(
        (m) => m.DashboardModule
      ),
    data: { preload: true },
  },
  {
    path: 'catalog',
    loadChildren: () =>
      import('./pages/catalog/catalog.module').then((m) => m.CatalogModule),
    data: { preload: true },
  },
  { path: '**', redirectTo: 'account' },
  { path: '', pathMatch: 'full', redirectTo: 'account' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
