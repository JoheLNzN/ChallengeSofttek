import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AppConsts } from 'src/shared/AppConsts';

import { UserRoleType } from './../account.service';

@Injectable()
export class LocalAuthStorageService {
  private _logOutSubject = new Subject<boolean>();
  _logOutChange$ = this._logOutSubject.asObservable();

  public save(authStorage: AuthStorage): void {
    localStorage.setItem(
      AppConsts.LOCALSTORAGE_AUTH,
      JSON.stringify(authStorage)
    );
  }

  public get(): AuthStorage | null {
    let authStorage = localStorage.getItem(AppConsts.LOCALSTORAGE_AUTH);
    return authStorage == null
      ? null
      : (JSON.parse(authStorage) as AuthStorage);
  }

  logOut() {
    localStorage.clear();
    this._logOutSubject.next(true);
  }
}

export class AuthStorage {
  token: string;
  role: UserRoleType;
  emailAddress: string;
  constructor(token: string, role: UserRoleType, emailAddress: string) {
    this.token = token;
    this.role = role;
    this.emailAddress = emailAddress;
  }
}
