import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../../shared/models/product';

@Component({
  selector: 'app-product-item',
  standalone: false,
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss',
})
export class ProductItemComponent implements OnInit {
  
  @Input() product!:IProduct;
  
  constructor() {}


  ngOnInit() {}
}
//and in order to receive something from a parent component and our shop component is the parent of product-item-components

//then what we need to use is an input property this is going to receive an input property from its parents component , so in ProductItemComponent we need to add an input
