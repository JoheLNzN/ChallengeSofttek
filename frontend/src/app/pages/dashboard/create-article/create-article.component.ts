import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs';

import { ArticleCreateInputDto, ArticleService } from './../../../../shared/services/article.service';

@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html',
  styleUrls: ['./create-article.component.scss'],
})
export class CreateArticleComponent implements OnInit, AfterViewInit {
  @ViewChild('name', { static: false })
  name: ElementRef<HTMLInputElement>;

  frmArticle: FormGroup;
  busy: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private articleService: ArticleService,
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {
    this.frmArticle = this.fb.group({
      formName: new FormControl('', [Validators.required]),
      formPrice: new FormControl('', [Validators.required]),
      formStock: new FormControl('10', [Validators.required]),
    });
  }

  ngAfterViewInit(): void {
    this.name.nativeElement.focus();
  }

  create(): void {
    if (this.busy) return;
    this.busy = true;

    let input = new ArticleCreateInputDto(
      this.frmArticle.controls['formName'].value,
      this.frmArticle.controls['formPrice'].value,
      this.frmArticle.controls['formStock'].value
    );

    this.articleService
      .create(input)
      .pipe(
        finalize(() => {
          this.busy = false;
        })
      )
      .subscribe({
        complete: () => {
          this.router.navigate(['dashboard/index']);
          this.toastr.success('El artículo fue registrado.', 'Éxito', {
            positionClass: 'toast-bottom-right',
          });
        },
        error: (err) => console.error(err),
      });
  }
}
