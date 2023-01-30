import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';

import { ArticleDto, ArticleService } from './../../../../shared/services/article.service';
import { DefaultResponse } from './../../../../shared/services/shared.service';

@Component({
  selector: 'app-dashboard-index',
  templateUrl: './dashboard-index.component.html',
  styleUrls: ['./dashboard-index.component.scss'],
})
export class DashboardIndexComponent implements OnInit {
  articles: ArticleDto[] = [];

  loading: boolean = true;

  constructor(private router: Router, private articleService: ArticleService) {}

  ngOnInit(): void {
    this.loadArticles();
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
