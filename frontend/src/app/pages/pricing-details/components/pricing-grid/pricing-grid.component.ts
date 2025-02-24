import { Component, Input } from "@angular/core";
import { PricingService } from "src/app/core/services/pricing.service";
import { Product } from "src/app/core/types/product.types";

@Component({
    selector: "pricing-grid",
    templateUrl: "./pricing-grid.component.html",
    styleUrls: ["./pricing-grid.component.css"]
})
export class PricingGridComponent {

    @Input() product!: Product;
    
    constructor(
        readonly pricingService: PricingService,
    ) {}
}