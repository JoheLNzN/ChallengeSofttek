import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { LocalStorageService } from '../../../shared/services/local/local-storage.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {

  constructor(
    private _router: Router,
    private _localStorageService: LocalStorageService
  ) {}

  logOut(): void {
    this._localStorageService.logOut();
    this._router.navigate(['account/login']);
  }
}
