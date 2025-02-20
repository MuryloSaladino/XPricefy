import { Component } from '@angular/core';
import { AuthService } from './core/services/auth.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'frontend';

    constructor(
        private readonly authService: AuthService
    ) {
        console.log(authService);
        
    }
}
