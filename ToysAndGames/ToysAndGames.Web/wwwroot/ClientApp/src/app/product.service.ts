import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  toysAndGamesUrl = 'https://localhost:44354/api';

  constructor(private http: HttpClient) { }

  getProduct(){
    return this.http.get(`${this.toysAndGamesUrl}/product`);
  }
}
