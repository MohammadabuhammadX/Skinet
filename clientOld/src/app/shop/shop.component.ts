import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IType } from '../shared/models/productType';
import { IBrand } from '../shared/models/brand';
import { ShopParams } from '../shared/models/shopParams';


@Component({
  selector: 'app-shop',
  standalone: false,
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: Product[] = [];
  types: IType[] = [];
  brands: IBrand[] = [];
  shopParams = new ShopParams();
  totalCount: number =0;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price:High to low', value: 'priceDesc' },
  ];

  constructor(private shopService: ShopService) {}

  ngOnInit() {
    this.getProducts();
    this.getTypes();
    this.getBrands();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(
      (response) => {
        if (response) {
          this.products = response.data || [];
          this.shopParams.pageNumber = response.pageIndex;
          this.shopParams.pageSize = response.pageSize;
          this.totalCount = response.count;
        } else {
          this.products = [];
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      (response) => {
        this.brands = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getTypes() {
    this.shopService.getTypes().subscribe(
      (response) => {
        this.types = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onPageChanged(event:any){
    this.shopParams.pageNumber = event.page;
    this.getProducts();
  }
}

//it will be responsible for displaying the list of the components as well as providing pagination functionality sorting the search componenet and all of this functionality that we're going to add

//2-we have to subscribe so thaat we actually execute the call to the API, if we don't subscribe nothing happens

//3- error while coding the getBrands : before adding [] to let the compiler knows that we use array

// we know that our response is a type of Ibrands and we getting error here because it's telling us that Ibrand missing the following properties from type'IBrand[]': length, pop, push, concat, and 25 more,
// all of these are array methods and what this means is that in our shopService we didnt specify the IBrand as an array
//because we're specifying a different type in our component to what we're actually returning it gives us a warning and tells us that we need to do something slightly differently
