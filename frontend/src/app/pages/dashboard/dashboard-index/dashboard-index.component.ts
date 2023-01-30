import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';

import { ArticleDto, ArticleService } from './../../../../shared/services/article.service';
import { OrderService } from './../../../../shared/services/order.service';
import { DefaultResponse } from './../../../../shared/services/shared.service';
import {
  DashBoardSignalrService,
  SignalRDashboardResponseDto,
} from './../../../../shared/services/signalr/dashboard.signalr.service';

@Component({
  selector: 'app-dashboard-index',
  templateUrl: './dashboard-index.component.html',
  styleUrls: ['./dashboard-index.component.scss'],
})
export class DashboardIndexComponent implements OnInit {
  articles: ArticleDto[] = [];

  dashboard = new SignalRDashboardResponseDto();

  loading: boolean = true;

  constructor(
    private router: Router,
    private articleService: ArticleService,
    private orderService: OrderService,
    private dashboardSignalrService: DashBoardSignalrService
  ) {
    this.dashboardSignalrService.init();
  }

  ngOnInit(): void {
    this.loadArticles();
    this.loadDashboard();
    this.dashboardSignalrService.$dashboardSubject.subscribe(
      (reponse: SignalRDashboardResponseDto) => {
        console.log(reponse);
        this.dashboard = reponse;
        this.loadArticles();
      }
    );
  }

  loadDashboard(): void {
    this.orderService.getDashboard().subscribe({
      next: (response: DefaultResponse) => {
        if (response.isSuccess)
          this.dashboard = <SignalRDashboardResponseDto>response.result;
      },
      error: (err) => console.error(err),
    });
  }

  loadArticles(): void {
    this.articleService
      .getAll()
      .pipe(
        finalize(() => {
          this.loading = false;
        })
      )
      .subscribe({
        next: (response: DefaultResponse) => {
          console.log(response);
          if (response.isSuccess) this.articles = <ArticleDto[]>response.result;
        },
        error: (err) => console.error(err),
      });
  }

  goCreateArticle(): void {
    this.router.navigate(['dashboard/create-article']);
  }
}
