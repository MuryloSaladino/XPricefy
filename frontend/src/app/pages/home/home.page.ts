import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ProductsRepository } from "src/app/core/repositories/products.repository";
import { ProductSummary } from "src/app/core/types/product.types";

@Component({
    selector: "app-home",
    templateUrl: "./home.page.html",
    styleUrls: ["home.page.css"],
})
export class HomePage implements OnInit {

    products!: ProductSummary[];
    openModal: boolean = false;

    constructor(
        private readonly productsRepository: ProductsRepository,
    ) {}

    async ngOnInit() {
        await this.handleUpdateProducts();
    }
    
    async handleUpdateProducts() {
        this.products = await this.productsRepository.findAllProducts();
    }

    handleOpenModal() {
        this.openModal = true;
    }
    handleCloseModal() {
        this.openModal = false;
    }
}