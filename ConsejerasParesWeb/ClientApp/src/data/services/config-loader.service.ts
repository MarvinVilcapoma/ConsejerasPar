import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../schemas/configuration/appConfig';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConfigLoaderService {

  public urlAPI = "";

  constructor(private httpClient: HttpClient) { }

  initialize() {
    return this.httpClient.get<AppConfig>('./assets/config.json').pipe(tap((response: AppConfig) => {
      this.urlAPI = response.urlApi;
      console.log(this.urlAPI)
    }));
  }
}