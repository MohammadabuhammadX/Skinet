import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root',
}) // this is initialized when our application starts so our serivces are Singletons which means they're always available as long as our app is available, they're not like components where angular is going to initialize them and then destroy them as soon as we move away from the component this is always going to be available for it's an excellent place to hold data look we need to chare across the application and good place to inject out HTTP service nd go and make out API calls to go and retrieve data and then we can consume the data from our serivce inside out components
export class ShopService {
  baseUrl = 'https://localhost:5287/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: ShopParams) {
  let params = new HttpParams();

  if (shopParams.brandId !==0) {
    params = params.append('brandId', shopParams.brandId.toString());
  }

  if (shopParams.typeId !==0) {
    params = params.append('typeId', shopParams.typeId.toString());
  }
  params = params.append('sort',shopParams.sort);
  params = params.append('search', shopParams.search); 
  params = params.append('pageIndex', shopParams.pageNumber.toString());
  params = params.append('pageSize', shopParams.pageSize.toString());
  return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', 
    {observe: 'response',params,}).pipe(map(response => response.body)
  );
}
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
//Angular services are considered as Singletons, they're initialized when our application starts
