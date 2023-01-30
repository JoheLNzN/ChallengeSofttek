import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs';
import { ArticleDto, ArticleService } from 'src/shared/services/article.service';
import { DefaultResponse } from 'src/shared/services/shared.service';

import { OrderCreateInputDto, OrderService } from './../../../../shared/services/order.service';
import { DashBoardSignalrService } from './../../../../shared/services/signalr/dashboard.signalr.service';

@Component({
  selector: 'app-catalog-index',
  templateUrl: './catalog-index.component.html',
  styleUrls: ['./catalog-index.component.scss'],
})
export class CatalogIndexComponent implements OnInit {
  articles: ArticleDto[] = [];

  loading: boolean = true;
  busy: boolean = false;

  constructor(
    private articleService: ArticleService,
    private orderService: OrderService,
    private dashBoardSignalrService: DashBoardSignalrService,
    private toastr: ToastrService
  ) {
    this.dashBoardSignalrService.init();
  }

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
                a.quantityToBuy = 0;
                a.amountToBuy = 0;

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

  changeQuantity(article: ArticleDto): void {
    article.amountToBuy = article.quantityToBuy * article.price;
  }

  buyArticle(btn: HTMLButtonElement, article: ArticleDto): void {
    if (article.quantityToBuy < 1 || article.amountToBuy < 1) {
      this.toastr.error('La cantidad de producto no es válido.', 'Éxito', {
        positionClass: 'toast-bottom-right',
      });
      return;
    }

    if (this.busy) return;
    this.busy = true;

    btn.innerText = 'Realizando pago...';
    this.orderService
      .create(new OrderCreateInputDto(article.sku, article.quantityToBuy))
      .pipe(
        finalize(() => {
          this.busy = false;
          btn.innerText = 'Pagar & Comprar';
        })
      )
      .subscribe({
        complete: () => {
          this.dashBoardSignalrService.soldArticle();
          this.loadArticles();
          this.toastr.success('La compra se realizó correctamente.', 'Éxito', {
            positionClass: 'toast-bottom-right',
          });
        },
        error: (err) => console.error(err),
      });
  }
}
