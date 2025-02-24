import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Product } from "src/app/core/types/product.types";

@Component({
    selector: "product-header",
    templateUrl: "./product-header.component.html",
    styleUrls: ["./product-header.component.css"]
})
export class ProductHeaderComponent {

    @Input() product!: Product;
    
    @Output() onEdit = new EventEmitter<void>();

    openModal: boolean = false;

    handleOpenModal() {
        this.openModal = true;
    }
    handleCloseModal() {
        this.openModal = false;
    }
}