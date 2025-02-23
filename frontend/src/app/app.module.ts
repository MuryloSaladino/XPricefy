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

        // Pipes
        BrlCurrencyPipe,
        FormatDatePipe,
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
