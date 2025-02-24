import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ProductsRepository } from "src/app/core/repositories/products.repository";
import { UsersRepository } from "src/app/core/repositories/users.repository";
import { PricingService } from "src/app/core/services/pricing.service";
import { Product } from "src/app/core/types/product.types";

@Component({
    selector: "app-pricing-details",
    templateUrl: "./pricing-details.page.html",
    styleUrls: ["./pricing-details.page.css"]
})
export class PricingDetails implements OnInit {
    
    productId: string | null = null;
    product!: Product;
    loading: boolean = true;

    constructor(
        private readonly productsRepository: ProductsRepository,
        private readonly route: ActivatedRoute,
        readonly pricingService: PricingService,
        readonly router: Router,
    ) {
        this.productId = route.snapshot.paramMap.get("id");
    }
    
    async ngOnInit(): Promise<void> {
        setTimeout(async () => {
            await this.updateProduct();
            this.loading = false;
        }, 1)
    }

    async updateProduct() {
        this.product = await this.productsRepository.findProductById(this.productId!);
    }
}