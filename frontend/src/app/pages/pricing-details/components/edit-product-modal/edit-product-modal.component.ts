import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ProductsRepository } from "src/app/core/repositories/products.repository";
import { Product } from "src/app/core/types/product.types";

@Component({
    selector: "edit-product-modal",
    templateUrl: "./edit-product-modal.component.html",
    styleUrls: ["./edit-product-modal.component.css"]
})
export class EditProductModal implements OnInit {

    editProductForm!: FormGroup;

    @Input() product!: Product;

    @Output() onClose = new EventEmitter<void>();
    @Output() onEdit = new EventEmitter<void>();

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly productsRepository: ProductsRepository,
    ) {}

    ngOnInit(): void {
        this.editProductForm = this.formBuilder.group({
            name: [this.product.name, [Validators.required, Validators.minLength(3)]],
            price: [this.product.price, [Validators.required, Validators.min(0)]],
            clientsNumber: [this.product.clientsNumber, [Validators.required, Validators.min(0)]],
            yearsToPay: [this.product.yearsToPay, [Validators.required, Validators.min(0), Validators.max(5)]],
        })
    }

    closeModal() {
        this.onClose.emit();
    }

    async submit() {
        try {
            const name = this.editProductForm.value.name;
            const price = Number(this.editProductForm.value.price);
            const clientsNumber = Number(this.editProductForm.value.clientsNumber);
            const yearsToPay = Number(this.editProductForm.value.yearsToPay);

            await this.productsRepository.updateProduct(this.product.id, {
                name,
                price,
                clientsNumber,
                yearsToPay,
            });
            
            this.closeModal();
            this.onEdit.emit();
        } catch {
            
        }
    }
}