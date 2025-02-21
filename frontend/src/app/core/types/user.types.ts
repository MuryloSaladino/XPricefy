import { BaseEntity } from "./entity.types";

export interface User extends BaseEntity {
    username: string;
}

export interface UserCreation {
    username: string;
    password: string;
}