import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPage } from './pages/login/login.page';
import { HomePage } from './pages/home/home.page';
import { TokenHeaderInterceptor } from './core/interceptors/token-header.interceptor';
import { ButtonComponent } from './shared/button/button.component';
import ModalComponent from './shared/modal/modal.component';
import { IconComponent } from './shared/icon/icon.component';
import { InputComponent } from './shared/input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AppComponent,
        
        // Pages
        LoginPage,
        HomePage,

        // Shared Components
        ButtonComponent,
        ModalComponent,
        IconComponent,
        InputComponent,
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
