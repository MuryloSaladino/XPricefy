import { BaseEntity } from "./entity.types";

export interface User extends BaseEntity {
    username: string;
}

export interface UserCreation extends Omit<User, keyof BaseEntity> {
    password: string
}