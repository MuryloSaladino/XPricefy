import { Component, Input, OnInit } from "@angular/core";
import { UsersRepository } from "src/app/core/repositories/users.repository";
import { ProductHistory } from "src/app/core/types/product-history.types";
import { User } from "src/app/core/types/user.types";

@Component({
    selector: "product-history",
    templateUrl: "./product-history.component.html",
    styleUrls: ["./product-history.component.css"]
})
export class ProductHistoryComponent implements OnInit {

    @Input() history!: ProductHistory;
    user: User | null = null;

    constructor(
        private readonly usersRepository: UsersRepository, 
    ) {}

    async ngOnInit(): Promise<void> {
        this.user = await this.usersRepository.findUserById(this.history.userId);
    }
}