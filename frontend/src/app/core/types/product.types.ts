import { BaseEntity } from "./entity.types";
import { ProductHistory } from "./product-history.types";

export interface Product extends BaseEntity {
    name: string;
	annualPrice: number;
	clientsNumber: number;
	yearsToPay: number;
    productHistories: ProductHistory[];
}

export interface ProductSummary extends 
    Pick<Product, "id" | "updatedAt" | "name" | "annualPrice"> {}

export interface ProductCreation extends 
    Omit<Product, keyof BaseEntity | "productHistories"> {}
