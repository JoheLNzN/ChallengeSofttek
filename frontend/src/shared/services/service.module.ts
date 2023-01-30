import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AccountService } from './account.service';
import { ArticleService } from './article.service';
import { LocalAuthStorageService } from './local/local-auth-storage.service';
import { OrderService } from './order.service';

@NgModule({
  imports: [CommonModule],
  providers: [
    AccountService,
    ArticleService,
    OrderService,
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
