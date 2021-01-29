import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { ProductService } from '../app/Services/Product/product.service';


import { AppComponent } from './app.component';
import { HomeComponent } from '../app/Components/Home/home.component';




// определение маршрутов
const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule
  ],
  declarations: [
    AppComponent,
    HomeComponent
  ],
  bootstrap: [AppComponent],
  providers: [
    ProductService,
  ]
})
export class AppModule { }
