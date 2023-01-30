import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AccountService } from './account.service';
import { ArticleService } from './article.service';
import { LocalAuthStorageService } from './local/local-auth-storage.service';

@NgModule({
  imports: [CommonModule],
  providers: [
    AccountService,
    ArticleService,
    LocalAuthStorageService
    // {
    //   provide: APP_INITIALIZER,
    //   useFactory: (signalr: ArticleSignalrService) => () => signalr.init(),
    //   deps: [ArticleSignalrService],
    //   multi: true,
    // },
  ],
})
export class ServiceModule {}
