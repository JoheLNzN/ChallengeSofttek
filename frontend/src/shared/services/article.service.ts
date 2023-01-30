import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AppConsts } from '../AppConsts';
import { LocalAuthStorageService } from './local/local-auth-storage.service';
import { DefaultResponse } from './shared.service';

@Injectable()
export class ArticleService {
  private API_URL: string = '';

  constructor(
    private http: HttpClient,
    private authStorageService: LocalAuthStorageService
  ) {
    this.API_URL = AppConsts.backendBaseUrl;
  }

  getAll(): Observable<DefaultResponse> {
    let storage = this.authStorageService.get();

    let headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
    });

    if (storage != null)
      headers = headers.append('Authorization', `Bearer ${storage.token}`);

    return this.http.get<DefaultResponse>(
      `${this.API_URL}/api/articles/getAll`,
      {
        headers: headers,
      }
    );
  }

  create(input: ArticleCreateInputDto) {
    let storage = this.authStorageService.get();

    if (storage == null)
      throw new Error(
        'Es necesario estar autenticado para realizar esta acción.'
      );

    let _url: string = `${this.API_URL}/api/articles/create`;

    let _headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      Authorization: `Bearer ${storage.token}`,
    });

    return this.http.post(_url, JSON.stringify(input), {
      headers: _headers,
    });
  }
}

export class ArticleDto {
  sku: string;
  name: string;
  price: number;
  stock: number;
  stockArray: number[] = [];
  creationTime: any;
}

export class ArticleCreateInputDto {
  name: string;
  price: number;
  stock: number;

  constructor(name: string, price: number, stock: number) {
    this.name = name;
    this.price = price;
    this.stock = stock;
  }
}
