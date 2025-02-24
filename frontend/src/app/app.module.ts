import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPage } from './pages/login/login.page';
import { HomePage } from './pages/home/home.page';
import { TokenHeaderInterceptor } from './core/interceptors/token-header.interceptor';
import { ButtonComponent } from './shared/button/button.component';
import { IconComponent } from './shared/icon/icon.component';
import { InputComponent } from './shared/input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductTableComponent } from './pages/home/components/products-table/product-table.component';
import { BrlCurrencyPipe } from './core/pipes/brl-currency.pipe';
import { FormatDatePipe } from './core/pipes/format-date.pipe';
import { HeaderComponent } from './shared/header/header.component';
import { CreateProductModal } from './pages/home/components/create-product-modal/create-product-modal.component';
import { AvatarComponent } from './shared/avatar/avatar.component';
import { PricingDetails } from './pages/pricing-details/pricing-details.page';
import { EurCurrencyPipe } from './core/pipes/eur-currency.pipe';
import { ProductHeaderComponent } from './pages/pricing-details/components/product-header/product-header.component';
import { PricingGridComponent } from './pages/pricing-details/components/pricing-grid/pricing-grid.component';
import { ProductHistoryComponent } from './pages/pricing-details/components/product-history/product-history.component';
import { HistoryActionNamePipe } from './core/pipes/history-action-name.pipe';
import { EditProductModal } from './pages/pricing-details/components/edit-product-modal/edit-product-modal.component';

@NgModule({
    declarations: [
        AppComponent,
        
        // Pages
        HomePage,
        LoginPage,
        PricingDetails,

        // Shared Components
        AvatarComponent,
        ButtonComponent,
        HeaderComponent,
        IconComponent,
        InputComponent,

        // Page Components
        CreateProductModal,
        ProductTableComponent,
        ProductHeaderComponent,
        PricingGridComponent,
        ProductHistoryComponent,
        EditProductModal,

        // Pipes
        BrlCurrencyPipe,
        EurCurrencyPipe,
        FormatDatePipe,
        HistoryActionNamePipe,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,  
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenHeaderInterceptor,
            multi: true
        },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
