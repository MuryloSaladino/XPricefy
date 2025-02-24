import { Injectable } from "@angular/core";
import { UsersRepository } from "../repositories/users.repository";
import { ProductsRepository } from "../repositories/products.repository";
import { defaultPassword, usernameMocks } from "src/data/mocks/users.mocks";
import { AuthService } from "./auth.service";
import { productMocks } from "src/data/mocks/products.mocks";


@Injectable({
    providedIn: "root"
})
export class PopulateService {

    productsIds: string[] = []

    constructor(
        private readonly usersRepository: UsersRepository,
        private readonly productRepository: ProductsRepository,
        private readonly authService: AuthService,
    ) {}

    async populate() {
        for (const [i, username] of usernameMocks.entries()) {
            await this.usersRepository.createUser({ username, password: defaultPassword });
            await this.authService.login(username, defaultPassword);
    
            const product = await this.productRepository.createProduct(productMocks[i]);
            this.productsIds.push(product.id);
    
            this.authService.logout();
        }
    
        for (const username of usernameMocks) {
            await this.authService.login(username, defaultPassword);
            
            for (let i = 0; i < 5; i++) {
                const index = Math.floor(Math.random() * this.productsIds.length);
                await this.productRepository.updateProduct(this.productsIds[index], productMocks[index]);
            }

            this.authService.logout();
        }

        return { username: usernameMocks[0], password: defaultPassword }
    }
}