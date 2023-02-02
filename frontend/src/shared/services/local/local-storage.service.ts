import { Injectable } from '@angular/core';
import { AppConsts } from 'src/shared/AppConsts';

import { UserRoleType } from '../account.service';

@Injectable()
export class LocalStorageService {

  constructor(){
    const logoutChannel = new BroadcastChannel(AppConsts.BROADCAST_CHANNEL_LOGOUT);
    logoutChannel.postMessage(AppConsts.APP_MESSAGE_LOGOUT);
  }

  public save(authStorage: AuthStorage): void {
    localStorage.setItem(
      AppConsts.LOCALSTORAGE_AUTH,
      JSON.stringify(authStorage)
    );
  }

  public get(): AuthStorage | null {
    let authStorageStr: string | null = localStorage.getItem(
      AppConsts.LOCALSTORAGE_AUTH
    );

    return authStorageStr == null
      ? null
      : <AuthStorage>JSON.parse(authStorageStr);
  }

  public verifyUserLoggedAndGetUrlRedirect(): string | null {
    console.log('Verificando si está logieado');
    let authStorage = this.get();
    console.log(authStorage == null ? 'account/login' : authStorage.redirectTo);
    return authStorage == null ? 'account/login' : authStorage.redirectTo;
  }

  public clearAll(): void {
    localStorage.clear();
  }

  public logOut(): void {
    this.clearAll();
  }

  isInvalid(data: string): boolean {
    return (
      data == undefined ||
      data == null ||
      data == '' ||
      data.replace(' ', '').length == 0
    );
  }
}

export class AuthStorage {
  token: string;
  role: UserRoleType;
  redirectTo: string;
  constructor(token: string, role: UserRoleType, redirectTo: string) {
    this.token = token;
    this.role = role;
    this.redirectTo = redirectTo;
  }
}
