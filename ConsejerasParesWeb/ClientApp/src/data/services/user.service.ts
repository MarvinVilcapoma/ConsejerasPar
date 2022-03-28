import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from 'src/environments/environment';
import { ResponseBase } from "../schemas/base/response-base";
import { UserRequestV1 } from "../schemas/request/UserRequestV1";
import { UserRequestV2 } from "../schemas/request/UserRequestV2";
import { AuthResponseV1 } from "../schemas/response/AuthResponseV1";
import { UserResponseV3 } from "../schemas/response/UserResponseV3";
import { AuthService } from "./auth.service";
import { ConfigLoaderService } from "./config-loader.service";

@Injectable({
    providedIn: 'root'
})
export class UserService{
  
  constructor(private http: HttpClient,private config:ConfigLoaderService, private authService: AuthService) { }

  getByFilters(
   request: UserRequestV2
  ): Observable<ResponseBase<UserResponseV3>> {
   return this.http.post<ResponseBase<UserResponseV3>>(
     `${this.config.urlAPI}/User/GetByFilters`,
    // `${environment.url}/User/GetByFilters`,
     request, {headers: {
      'Access-Control-Allow-Origin': '*',
      "Accept": "*/*",
      'Authorization' : `Bearer ${this.authService.token}`
     } }
   );
  }

  registerUser(
    request: UserRequestV2
   ): Observable<ResponseBase<UserResponseV3>> {
    return this.http.post<ResponseBase<UserResponseV3>>(
      `${this.config.urlAPI}/User/RegisterUser`,
     // `${environment.url}/User/GetByFilters`,
      request, {headers: {
        'Access-Control-Allow-Origin': '*',
        "Accept": "*/*",
        'Authorization' : `Bearer ${this.authService.token}`
       } }
    );
  }

  getByFiltersParticipants(
    request: UserRequestV2
   ): Observable<ResponseBase<UserResponseV3>> {
    return this.http.post<ResponseBase<UserResponseV3>>(
      `${this.config.urlAPI}/User/GetByFiltersParticipants`,
     // `${environment.url}/User/GetByFilters`,
      request, {headers: {
        'Access-Control-Allow-Origin': '*',
        "Accept": "*/*",
        'Authorization' : `Bearer ${this.authService.token}`
       } }
    );
  }

  getByFiltersCounselors(
    request: UserRequestV2
   ): Observable<ResponseBase<UserResponseV3>> {
    return this.http.post<ResponseBase<UserResponseV3>>(
      `${this.config.urlAPI}/User/GetByFiltersCounselors`,
     // `${environment.url}/User/GetByFilters`,
      request, {headers: {
        'Access-Control-Allow-Origin': '*',
        "Accept": "*/*",
        'Authorization' : `Bearer ${this.authService.token}`
       } }
    );
  }

}