import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "./token.service";
import { BehaviorSubject, firstValueFrom } from "rxjs";
import { environment } from "src/environments/environment";
import { User } from "../types/user.types";
import { UsersRepository } from "../repositories/users.repository";

interface LoginResponse {
    token: string;
}
export interface LoginPayload {
    username: string;
    password: string;
}

@Injectable({
    providedIn: "root"
})
export class AuthService {

    private apiUrl: string = environment.apiUrl;
    private userSubject = new BehaviorSubject<User | null>(null);
    
    user$ = this.userSubject.asObservable();

    constructor(
        private readonly httpClient: HttpClient,
        private readonly tokenService: TokenService,
        private readonly usersRepository: UsersRepository
    ) {}

    async login(username: string, password: string): Promise<void> {
        const response = await firstValueFrom(this.httpClient.post<LoginResponse>(
            `${this.apiUrl}/auth/login`,
            { username, password }
        ));

        this.tokenService.saveToken(response.token);

        const decodedToken = this.tokenService.decodeToken();
        const userId = decodedToken.userId;

        const user = await this.usersRepository.findUserById(userId);
        this.userSubject.next(user);
    }

    verifyToken() {
        return this.tokenService.hasToken() && 
            !!this.tokenService.decodeToken().userId
    }

    logout(): void {
        this.tokenService.deleteToken();
        this.userSubject.next(null);
    }
}