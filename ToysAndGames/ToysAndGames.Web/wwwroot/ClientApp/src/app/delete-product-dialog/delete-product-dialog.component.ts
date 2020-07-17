import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { ProductService } from '../product.service';

@Component({
  selector: 'app-delete-product-dialog',
  templateUrl: './delete-product-dialog.component.html',
  styleUrls: ['./delete-product-dialog.component.css']
})
export class DeleteProductDialogComponent implements OnInit {

  constructor(private productService: ProductService,
    public dialogRef: MatDialogRef<DeleteProductDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  onCancelClick():void{
    this.dialogRef.close();
  }

  onOkClick(productId:number){
    this.productService.deleteProduct(productId).subscribe(
      res => {
        this.dialogRef.close();
      },
      err => {
        console.error(err);
        this.dialogRef.close();
      }
    );
  }

}
