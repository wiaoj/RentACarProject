import { RegisterModel } from './../../models/auth/register/registerModel';
import { TokenModel } from './../../models/tokenModel';
import { Observable } from 'rxjs';
import { LoginModel } from './../../models/auth/login/loginModel';
import { LocalStorageService } from './../localStorage/local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SingleResponseModel } from 'src/app/models/singleResponseModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = 'https://localhost:44388/api/auths';

  constructor(
    private httpClient: HttpClient,
    private localStorage: LocalStorageService
  ) {}

  login(loginModel: LoginModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = `${this.apiUrl}/login`;
    return this.httpClient.post<SingleResponseModel<TokenModel>>(
      newPath,
      loginModel
    );
  }

  isAuthenticated() {
    return this.localStorage.get('token') ? true : false;
  }

  //TODO
  register(registerModel: RegisterModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = `${this.apiUrl}/register`;
    return this.httpClient.post<SingleResponseModel<TokenModel>>(
      newPath,
      registerModel
    );
  }
}
