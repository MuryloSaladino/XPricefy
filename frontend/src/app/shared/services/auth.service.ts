import { Injectable } from "@angular/core";
import internalServices from "../httpRequests/internal.services";
import { IServiceResponse } from "../interfaces/service.interfaces";

@Injectable({ providedIn: "root" })
export default class AuthService {

    async login(username: string, password: string): Promise<IServiceResponse<{ token: string }>> {
        return await internalServices.post("/auth/login", {
            username, 
            password
        });
    }
}