import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';
import { AppConsts } from 'src/shared/AppConsts';
import { AccountService, AuthenticateInputDto, AuthenticateResponseDto } from 'src/shared/services/account.service';
import { AuthStorage } from 'src/shared/services/local/local-storage.service';
import { DefaultResponse } from 'src/shared/services/shared.service';

import { LocalStorageService } from '../../../../shared/services/local/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, AfterViewInit {
  @ViewChild('emailAddress', { static: false })
  emailAddress: ElementRef<HTMLInputElement>;

  @ViewChild('btnLogin', { static: false })
  btnLogin: ElementRef<HTMLButtonElement>;

  frmLogin: FormGroup;
  isCustomer: boolean = true;

  busy: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private accountService: AccountService,
    private _localStorageService: LocalStorageService
  ) {}

  ngOnInit(): void {
    this.frmLogin = this.fb.group({
      formEmailAddress: new FormControl(
        AppConsts.DEFAULT_CUSTOMER_CREDENTIAL_EMAIL,
        [Validators.required, Validators.email]
      ),
      formPassword: new FormControl(
        AppConsts.DEFAULT_CUSTOMER_CREDENTIAL_PASSWORD,
        [Validators.required]
      ),
    });

    let redirectTo =
      this._localStorageService.verifyUserLoggedAndGetUrlRedirect();
    if (redirectTo != null) this.router.navigate([redirectTo]);
  }

  ngAfterViewInit(): void {
    this.emailAddress.nativeElement.focus();
  }

  changeRole(): void {
    this.isCustomer = !this.isCustomer;

    this.frmLogin.setValue({
      formEmailAddress: this.isCustomer
        ? AppConsts.DEFAULT_CUSTOMER_CREDENTIAL_EMAIL
        : AppConsts.DEFAULT_ADMIN_CREDENTIAL_EMAIL,
      formPassword: this.isCustomer
        ? AppConsts.DEFAULT_CUSTOMER_CREDENTIAL_PASSWORD
        : AppConsts.DEFAULT_ADMIN_CREDENTIAL_PASSWORD,
    });
  }

  authenticate(): void {
    if (this.busy) return;
    this.busy = true;

    this.frmLogin.disable();

    if (this.frmLogin.invalid) {
      this.btnLogin.nativeElement.disabled = true;
      this.busy = false;
      return;
    }

    let authenticateInputDto = new AuthenticateInputDto(
      this.frmLogin.controls['formEmailAddress'].value,
      this.frmLogin.controls['formPassword'].value
    );

    this.accountService
      .authenticate(authenticateInputDto)
      .pipe(
        finalize(() => {
          this.busy = false;
          this.frmLogin.enable();
        })
      )
      .subscribe({
        next: (response: DefaultResponse) => {
          if (response.isSuccess) {
            let data = <AuthenticateResponseDto>response.result;

            this._localStorageService.save(
              new AuthStorage(data.token, data.role, data.redirectTo)
            );

            this.router.navigate([data.redirectTo]);
          }
        },
        error: (err) => {
          console.log(err);
        },
      });
  }
}
