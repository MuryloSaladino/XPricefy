import { Injectable } from "@angular/core";
import { Product, ProductSummary } from "../types/product.types";

const MARGIN = 0.05;
const EURO_PRICE = 5.75;

@Injectable({
    providedIn: "root"
})
export class PricingService {

    getCostWithMargin(product: Product | ProductSummary) {
        return product.price * (1 + MARGIN);
    }

    getAnnualCost(product: Product) {
        return product.price / product.yearsToPay;
    }

    getCostPerClient(product: Product) {
        return this.getAnnualCost(product) / product.clientsNumber;
    }

    getCostPerClientWithTax(product: Product) {
        return this.getCostPerClient(product) * (1 + MARGIN);
    }

    getCostPerClientWithEuroTax(product: Product) {
        return this.getCostPerClientWithTax(product) / EURO_PRICE;
    }

    getMensalCostPerClientWithEuroTax(product: Product) {
        return this.getAnnualCost(product) / 12 / product.clientsNumber * (1 + MARGIN) / EURO_PRICE;
    }
}