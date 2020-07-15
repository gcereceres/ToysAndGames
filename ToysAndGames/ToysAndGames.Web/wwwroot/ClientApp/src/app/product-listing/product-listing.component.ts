import { Component, OnInit } from '@angular/core';

import { ProductService } from '../product.service';
import { Product } from '../product';


@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.css']
})
export class ProductListingComponent implements OnInit {

  constructor(private productService: ProductService) { }

  productList: Product[] = [];

  ngOnInit(): void {

    this.productService
      .getProduct()
      .subscribe((data:Product[]) => this.productList = data);
  }

}
