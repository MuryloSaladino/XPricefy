import { Injectable } from '@angular/core';

const STORAGE_KEY = '@TOKEN';

@Injectable({
    providedIn: 'root'
})
export class TokenService {

    saveToken(token: string) {
        return localStorage.setItem(STORAGE_KEY, token);
    }

    deleteToken() {
        localStorage.removeItem(STORAGE_KEY);
    }

    getToken() {
        return localStorage.getItem(STORAGE_KEY) ?? '';
    }
    
    hasToken() {
        return !!this.getToken();
    }
}


