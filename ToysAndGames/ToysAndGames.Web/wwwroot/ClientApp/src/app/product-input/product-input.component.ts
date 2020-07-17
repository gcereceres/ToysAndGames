import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { ProductService } from '../product.service';
import { Product } from '../product';

@Component({
  selector: 'app-product-input',
  templateUrl: './product-input.component.html',
  styleUrls: ['./product-input.component.css']
})
export class ProductInputComponent implements OnInit {

  constructor(
    private productService: ProductService,
    public dialogRef: MatDialogRef<ProductInputComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Product
  ) { }

  product: Product = <Product>{};

  ngOnInit(): void {
    if(this.data){
      this.product = this.data;
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    console.log(this.product);
    if(!this.product.id){
      this.productService.createProduct(this.product).subscribe(
        res => this.dialogRef.close(),
        err => 
        {
          console.log(err);
          this.dialogRef.close();
        }
      );
    } else {
      this.productService.updateProduct(this.product).subscribe(
        res => this.dialogRef.close(),
        err => 
        {
          console.log(err);
          this.dialogRef.close();
        }
      );
    }
  }

}
