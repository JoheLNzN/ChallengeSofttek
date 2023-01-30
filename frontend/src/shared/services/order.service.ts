import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AppConsts } from '../AppConsts';
import { LocalAuthStorageService } from './local/local-auth-storage.service';
import { DefaultResponse } from './shared.service';

@Injectable()
export class OrderService {
  private API_URL: string = '';

  constructor(
    private http: HttpClient,
    private authStorageService: LocalAuthStorageService
  ) {
    this.API_URL = AppConsts.backendBaseUrl;
  }

  getDashboard(): Observable<DefaultResponse> {
    return this.http.get<DefaultResponse>(
      `${this.API_URL}/api/orders/getDataDashboard`,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json; charset=utf-8',
        }),
      }
    );
  }

  create(input: OrderCreateInputDto) {
    let storage = this.authStorageService.get();

    if (storage == null)
      throw new Error(
        'Es necesario estar autenticado para realizar esta acción.'
      );

    let _url: string = `${this.API_URL}/api/orders/create`;

    let _headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      Authorization: `Bearer ${storage.token}`,
    });

    return this.http.post(_url, JSON.stringify(input), {
      headers: _headers,
    });
  }
}

export class OrderCreateInputDto {
  articleSku: string;
  quantity: number;
  constructor(articleSku: string, quantity: number) {
    this.articleSku = articleSku;
    this.quantity = quantity;
  }
}
