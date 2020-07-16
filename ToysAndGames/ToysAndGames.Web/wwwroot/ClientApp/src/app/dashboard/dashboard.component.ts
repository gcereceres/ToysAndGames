import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { ProductInputComponent } from '../product-input/product-input.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(ProductInputComponent, {
      //width: '250px',
      //data: {name: this.name, animal: this.animal}
    });

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    //   this.animal = result;
    // });
  }

  ngOnInit(): void {
  }

}
