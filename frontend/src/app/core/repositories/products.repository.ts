import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { firstValueFrom } from "rxjs";
import { Product, ProductCreation } from "../types/product.types";

@Injectable({
    providedIn: "root"
})
export class ProductsRepository {

    private apiUrl: string = environment.apiUrl;

    constructor(
        private readonly httpClient: HttpClient,
    ) {}
    
    async createProduct(payload: ProductCreation): Promise<Product> {
        return firstValueFrom(
            this.httpClient.post<Product>(`${this.apiUrl}/products`, payload)
        );
    }
    
    async findProductById(id: string): Promise<Product> {
        return firstValueFrom(
            this.httpClient.get<Product>(`${this.apiUrl}/products/${id}`)
        );
    }

    async findAllProducts(id: string): Promise<Product[]> {
        return firstValueFrom(
            this.httpClient.get<Product[]>(`${this.apiUrl}/products`)
        );
    }

    async updateProduct(id: string, payload: ProductCreation): Promise<Omit<Product, "productHistories">> {
        return firstValueFrom(
            this.httpClient.put<Omit<Product, "productHistories">>(
                `${this.apiUrl}/products/${id}`, payload
            )
        );
    }

    async deleteProduct(id: string): Promise<void> {
        await firstValueFrom(
            this.httpClient.delete(`${this.apiUrl}/products/${id}`)
        );
    }
}