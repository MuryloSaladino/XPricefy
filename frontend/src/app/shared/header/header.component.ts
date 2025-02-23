import { Component, OnInit } from "@angular/core";
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
    ) {}

    ngOnInit(): void {
        this.username = this.tokenService.decodeToken().username;
    }
}