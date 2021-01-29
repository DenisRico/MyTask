import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/Product/product.service';
import { Product } from '../../Models/Product';
//import { tap, finalize, takeUntil } from 'rxjs/operators';
import { ReplaySubject, Subscription } from 'rxjs';



@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  
})
export class HomeComponent implements OnInit {


  private subscriptions = new ReplaySubject<any>(1);

  products: Product[];                 // array of products
  product: Product = new Product();   // product for change
  tableMode: boolean = true;          // table

  subscr = new Array<Subscription>();


  constructor(
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.loadProducts();
  }

  s
  loadProducts() {
    this.productService.getProducts().subscribe((product: Product[]) => this.products = product);
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }

  delete(product: Product) {
    this.productService.deleteProduct(product.id).subscribe(data => this.loadProducts());
  }

  ///Edit of product funktion
  editProduct(product: Product) {
    this.product = product;
  }

  // сохранение данных
  save() {
    if (this.product.id == null) {
      console.log(this.product);
      this.productService.createProduct(this.product)
        .subscribe((data: Product) => this.products.push(data));
    } else {
      this.productService.updateProduct(this.product)
        .subscribe(data => this.loadProducts());
    }
    this.cancel();

  }

  cancel() {
    this.product = new Product();
    this.tableMode = true;

  }


  ngOnDestroy(): void {
    this.subscriptions.next(null);
    this.subscriptions.complete();

    this.subscr.forEach(subsc => {
      if (subsc) {
        subsc.unsubscribe();
      }
    })
  }

}
