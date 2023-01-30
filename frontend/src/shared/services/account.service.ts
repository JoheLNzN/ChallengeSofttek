import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AppConsts } from '../AppConsts';
import { DefaultResponse } from './shared.service';

@Injectable()
export class AccountService {
  private API_URL: string = '';

  constructor(private http: HttpClient) {
    this.API_URL = AppConsts.backendBaseUrl;
  }

  authenticate(
    input: AuthenticateInputDto
  ): Observable<DefaultResponse> {
    let _url = `${this.API_URL}/api/users/authenticate`;

    let headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
    });

    return this.http.post<DefaultResponse>(
      _url,
      JSON.stringify(input),
      {
        headers: headers,
      }
    );
  }
}

export class AuthenticateInputDto {
  emailAddress: string;
  password: string;

  constructor(emailAddress: string, password: string) {
    this.emailAddress = emailAddress;
    this.password = password;
  }
}

export class AuthenticateResponseDto {
  token: string;
  role: UserRoleType;
}

export enum UserRoleType {
  DEFAULT,
  ADMIN,
}
