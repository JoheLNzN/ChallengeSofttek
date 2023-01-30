import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs';
import { ArticleDto, ArticleService } from 'src/shared/services/article.service';
import { DefaultResponse } from 'src/shared/services/shared.service';

@Component({
  selector: 'app-catalog-index',
  templateUrl: './catalog-index.component.html',
  styleUrls: ['./catalog-index.component.scss'],
})
export class CatalogIndexComponent implements OnInit {
  articles: ArticleDto[] = [];

  loading: boolean = true;
  busy: boolean = false;

  constructor(private articleService: ArticleService) {}

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
          if (response.isSuccess) {
            this.articles = <ArticleDto[]>response.result;
            if (this.articles.length > 0) {
              this.articles.forEach((a) => {
                if (a.stock > 0) {
                  a.stockArray = [];
                  for (let i = 1; i <= a.stock; i++) a.stockArray.push(i);
                }
              });
            }
          }
        },
        error: (err) => console.error(err),
      });
  }

  buyArticle(btn: HTMLButtonElement, article: ArticleDto): void{
    if(this.busy) return;
    this.busy = true;

    btn.innerText = 'Realizando pago...';
    btn.classList.add('btnPaying');
  }
}
