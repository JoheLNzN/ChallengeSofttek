import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { AppConsts } from 'src/shared/AppConsts';

@Injectable()
export class DashBoardSignalrService {
  private _url: string;
  connection: HubConnection;

  $dashboardSubject: Subject<SignalRDashboardResponseDto>;

  constructor() {
    this.$dashboardSubject = new Subject<SignalRDashboardResponseDto>();
    this._url = `${AppConsts.backendBaseUrl}/dashboardHub`;
  }

  public async init(): Promise<void> {
    try {
      this.connection = new HubConnectionBuilder()
        .withUrl(this._url)
        .withAutomaticReconnect()
        .build();

      await this.connection.start();

      this.notifications();
    } catch (error) {
      console.error(`SignalR | Connection-Error: ${error}`);
    }
  }

  private notifications(): void {
    this.connection.on('notifyNewPurchase', (response: SignalRDashboardResponseDto) => {
      this.$dashboardSubject.next(response);
    });
  }

  public async soldArticle(): Promise<void> {
    await this.connection.invoke('SoldArticle');
  }
}

export class SignalRDashboardResponseDto{
  totalSales: number = 0;
  totalOrders: number = 0;
  articlesSold: number = 0;
  noStockArticles: number = 0;
}
