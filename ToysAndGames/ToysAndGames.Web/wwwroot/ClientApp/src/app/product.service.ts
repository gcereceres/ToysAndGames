import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  toysAndGamesUrl = 'https://localhost:44354/api/product';

  constructor(private http: HttpClient) { }

  getProduct(){
    return this.http.get(this.toysAndGamesUrl);
  }

  createProduct(product:Product){
    return this.http.post(this.toysAndGamesUrl, product);
  }

  deleteProduct(productId:number){
    return this.http.delete(`${this.toysAndGamesUrl}/${productId}`);
  }

  updateProduct(product: Product){
    return this.http.put(this.toysAndGamesUrl, product);
  }
}
