import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { ProductInputComponent } from '../product-input/product-input.component';
import { DeleteProductDialogComponent } from '../delete-product-dialog/delete-product-dialog.component';
import { ProductService } from '../product.service';
import { Product } from '../product';


@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.css']
})
export class ProductListingComponent implements OnInit {

  constructor(private productService: ProductService, 
              public dialog: MatDialog) { }

  productList: Product[] = [];

  ngOnInit(): void {
    this.getProductList();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ProductInputComponent, {
      //width: '250px',
      //data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getProductList();
    });

  }

  onUpdateClick(product: Product){
    const UpdateDialogRef = this.dialog.open(ProductInputComponent, {
      //width: '250px',
      data: product
    });

    UpdateDialogRef.afterClosed().subscribe(result => {
      this.getProductList();
    });
  }

  onDelete(productId, productName): void {

    const deletedialogRef = this.dialog.open(DeleteProductDialogComponent, {
      //width: '250px',
      data: {name: productName, id: productId}
    });

    deletedialogRef.afterClosed().subscribe(result => {
      this.getProductList();
    });
  }

  getProductList(): void {
    this.productService
    .getProduct()
    .subscribe((data:Product[]) => 
    {
      this.productList = data
    });
  }

}
