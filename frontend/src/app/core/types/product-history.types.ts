import { BaseEntity } from "./entity.types";

export enum HistoryAction {
    Created = 1,
    Updated = 2,
    Deleted = 3,
}

export interface ProductHistory extends BaseEntity {
    userId: string;
    productId: string;
    action: HistoryAction;
}