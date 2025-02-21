import { enableProdMode } from '@angular/core';

import 'rxjs/add/operator/map';

import { environment } from './environments/environment';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { AppRoutingModule } from './app/app-routing.module';

if (environment.production) {
    enableProdMode();
}

bootstrapApplication(AppComponent, {
    providers: [AppRoutingModule]
}).catch(err => console.error(err));
