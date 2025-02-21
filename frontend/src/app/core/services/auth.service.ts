import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "./token.service";
import { Observable, tap } from "rxjs";
import { environment } from "src/environments/environment";

interface LoginResponse {
    token: string;
}

@Injectable({
    providedIn: "root"
})
export class AuthService {

    private apiUrl: string = environment.apiUrl;
    
    constructor(
        private readonly httpClient: HttpClient,
        private readonly tokenService: TokenService
    ) {}

    login(username: string, password: string): Observable<HttpResponse<LoginResponse>> {
        return this.httpClient.post<LoginResponse>(
            `${this.apiUrl}/auth/login`,
            { username, password },
            { observe: "response" }
        ).pipe(
            tap((response) => {
                const token = response.body?.token || "";
                this.tokenService.saveToken(token);
            })
        )
    }
}