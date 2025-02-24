import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ProductsRepository } from "src/app/core/repositories/products.repository";

@Component({
    selector: "create-product-modal",
    templateUrl: "./create-product-modal.component.html",
    styleUrls: ["./create-product-modal.component.css"]
})
export class CreateProductModal implements OnInit {

    createProductForm!: FormGroup;

    @Input() productId!: string | null;

    @Output() onClose = new EventEmitter<void>();
    @Output() onCreation = new EventEmitter<void>();


    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly productsRepository: ProductsRepository,
    ) {}

    ngOnInit(): void {
        this.createProductForm = this.formBuilder.group({
            name: [null, [Validators.required, Validators.minLength(3)]],
            price: [null, [Validators.required, Validators.min(0)]],
            clientsNumber: [null, [Validators.required, Validators.min(0)]],
            yearsToPay: [null, [Validators.required, Validators.min(0), Validators.max(5)]],
        })
    }

    closeModal() {
        this.onClose.emit();
    }

    async submit() {
        try {
            const name = this.createProductForm.value.name;
            const price = Number(this.createProductForm.value.price);
            const clientsNumber = Number(this.createProductForm.value.clientsNumber);
            const yearsToPay = Number(this.createProductForm.value.yearsToPay);

            await this.productsRepository.createProduct({
                name,
                price,
                clientsNumber,
                yearsToPay,
            });
            
            this.closeModal();
            this.onCreation.emit();
        } catch {
            
        }
    }
}