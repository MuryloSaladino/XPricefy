import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "src/app/core/services/auth.service";
import { TokenService } from "src/app/core/services/token.service";

@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit {
    
    username: string = "";
    
    constructor(
        private readonly tokenService: TokenService,
        private readonly authService: AuthService,
        private readonly router: Router,
    ) {}

    ngOnInit(): void {
        this.username = this.tokenService.decodeToken().username;
    }

    logout() {
        this.authService.logout();
        this.router.navigate(["/login"]);
    }
}