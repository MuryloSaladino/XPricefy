import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { User, UserCreation } from "../types/user.types";
import { firstValueFrom } from "rxjs";

@Injectable({
    providedIn: "root"
})
export class UsersRepository {

    private apiUrl: string = environment.apiUrl;

    constructor(
        private readonly httpClient: HttpClient,
    ) {}
    
    async findUserById(id: string): Promise<User> {
        return firstValueFrom(
            this.httpClient.get<User>(`${this.apiUrl}/users/${id}`)
        );
    }

    async createUser(payload: UserCreation): Promise<User> {
        return firstValueFrom(
            this.httpClient.post<User>(`${this.apiUrl}/users`, payload)
        );
    }
}