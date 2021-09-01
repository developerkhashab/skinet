import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/Models/brand';
import { IProduct } from '../shared/Models/product';
import { IProductType } from '../shared/Models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products : IProduct[];
  brands : IBrand[];
  productTypes : IProductType[];
  brandIdSelected: number;
  typeIdSelected: number;

  constructor(private shopService : ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getProductTypes();
  }

  getProducts(){
    this.shopService.getProducts().subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe(response => {
      this.brands = response;
    }, error => {
      console.log(error);
    });
  }

  getProductTypes(){
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypes = response;
    }, error => {
      console.log(error);
    });
  }

}
