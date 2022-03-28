import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseBase } from '../schemas/base/response-base';
import { UserRequestV1 } from '../schemas/request/UserRequestV1';
import { AuthResponseV1 } from '../schemas/response/AuthResponseV1';
import { UserResponseV1 } from '../schemas/response/UserResponseV1';
import { UserResponseV2 } from '../schemas/response/UserResponseV2';
import { ConfigLoaderService } from './config-loader.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {

  private _usuario!: UserResponseV2;
  private _token!: string;

  constructor(private http: HttpClient,private config:ConfigLoaderService) { }

  public get usuario(): UserResponseV2 {
    if (this._usuario == null && sessionStorage.getItem("usuario") != null) {
      this._usuario = JSON.parse(sessionStorage.getItem("usuario") || '{}') as UserResponseV2;
      return this._usuario;
    }
    return this._usuario;
  }

  public get token(): string | any {
    if (this._token != null) {
      return this._token;
    } else if (this._token == null && sessionStorage.getItem("token") != null) {
      this._token = sessionStorage.getItem("token") || '';
      return this._token;
    }
    return null;
  }
//   saveUser(auth: AuthResponseV1): void {
//     sessionStorage.setItem("usuario", JSON.stringify(auth));
//   }



  saveUser(accessToken: string): void {
    let payload = this.obtenerDatosToken(accessToken);
    console.log(payload)
    this._usuario = new UserResponseV2();
    this.usuario.userID = payload.id;
    this.usuario.fullName = payload.fullname;
    this.usuario.userName = payload.username; 
    // this._usuario.userName = payload.username;
    // this._usuario.email = payload.email;
    this._usuario.exp = payload.exp;
    console.log(this.usuario);
    sessionStorage.setItem("user", JSON.stringify(this._usuario));
  }

  guardarToken(accessToken: string): void {
    this._token = accessToken;
    sessionStorage.setItem("token", accessToken);
  }

  obtenerDatosToken(accessToken: string): any {
    if (accessToken != null) {
      return JSON.parse(atob(accessToken.split(".")[1]));
    }
    return null;
  } 

  Login(request: UserRequestV1): Observable<ResponseBase<AuthResponseV1>> {
    return this.http.post<any>(`${this.config.urlAPI}/Auth/Login`, request);
  }

  isAuthenticated(): boolean {
    // if (this.usuario != null && (this.usuario.role.roleID == 1 || this.usuario.role.roleID == 4)) { return true }
    // else { return false }
    return (this.usuario != null) ? true : false;
  }

  // logout(): void {
  //   this._usuario == null;
  //   sessionStorage.clear();
  //   sessionStorage.removeItem("usuario");
  // }

  logout(): void {
    this._token = "";
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("token");
  }
}