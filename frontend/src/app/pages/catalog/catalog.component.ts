import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { LocalStorageService } from '../../../shared/services/local/local-storage.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss'],
})
export class CatalogComponent{

  constructor(
    private _router: Router,
    private _localStorageService: LocalStorageService
  ) {}

  logOut(): void {
    this._localStorageService.logOut();
    this._router.navigate(['account/login']);
  }
}
