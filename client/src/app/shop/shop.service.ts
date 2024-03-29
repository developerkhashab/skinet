import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/Models/brand';
import { IPagination } from '../shared/Models/pagination';
import { IProductType } from '../shared/Models/productType';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'
  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number, sort?: string) {
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString())
    }

    if (typeId) {
      params = params.append('typeId', typeId.toString())
    }

    if(sort){
      params = params.append('sort',sort);
    }

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
    .pipe(
      map(reponse => {
        return reponse.body;
      })
    );
  }

  getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'ProductsType');
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'ProductsBrand');
  }
}
