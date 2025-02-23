import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { PricingService } from 'src/app/core/services/pricing.service';
import { ProductSummary } from 'src/app/core/types/product.types';

@Component({
    selector: 'product-table',
    templateUrl: './product-table.component.html',
    styleUrls: ['./product-table.component.css']
})
export class ProductTableComponent {

    @Input() products: ProductSummary[] = [];

    @Output() rowClicked = new EventEmitter<string>();
    
    constructor(
        readonly pricingService: PricingService,
        private readonly router: Router,
    ) {}

    navigateToDetails(id: string) {
        this.router.navigate(["/p", id])
    }
}