import { HttpClient } from '@angular/common/http';
import { Injectable, isDevMode } from '@angular/core';

import { AppConsts } from './AppConsts';

@Injectable({
  providedIn: 'root',
})
export class AppConfiguration {
  constructor(private http: HttpClient) {}

  init() {
    let json = isDevMode() ? 'appconfig.json' : 'appconfig.production.json';
    this.http.get<AppConfig>(`assets/${json}`).subscribe({
      next: (config: AppConfig) => {
        console.log('AppConfiguration loaded');
        AppConsts.backendBaseUrl = config.backendBaseUrl;
        AppConsts.clienteBaseUrl = config.clientBaseUrl;
      },
      error: (err) => console.error(err),
    });
  }
}

export class AppConfig {
  backendBaseUrl: string;
  clientBaseUrl: string;
}
