import { CommonModule } from '@angular/common';
import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AccountService } from './account.service';
import { ArticleService } from './article.service';
import { LocalStorageService } from './local/local-storage.service';
import { OrderService } from './order.service';
import { DashBoardSignalrService } from './signalr/dashboard.signalr.service';

@NgModule({
  imports: [CommonModule],
  providers: [
    AccountService,
    ArticleService,
    OrderService,
    LocalStorageService,
    DashBoardSignalrService,
    {
      provide: APP_INITIALIZER,
      useFactory: (signalr: DashBoardSignalrService) => () => signalr.init(),
      deps: [DashBoardSignalrService],
      multi: true,
    },
  ],
})
export class ServiceModule {}
