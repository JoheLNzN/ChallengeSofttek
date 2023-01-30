import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LocalAuthStorageService } from './../../../shared/services/local/local-auth-storage.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss'],
})
export class CatalogComponent implements OnInit {
  constructor(
    private router: Router,
    private localAuthStorageService: LocalAuthStorageService
  ) {}

  ngOnInit(): void {}

  logOut(): void {
    this.localAuthStorageService.logOut();
    this.router.navigate(['account/login'], { replaceUrl: true });
  }
}
