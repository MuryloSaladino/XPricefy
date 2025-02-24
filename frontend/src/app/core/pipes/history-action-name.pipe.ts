import { Pipe, PipeTransform } from "@angular/core";
import { HistoryAction } from "../types/product-history.types";

@Pipe({
    name: 'historyActionName'
})
export class HistoryActionNamePipe implements PipeTransform {
    transform(value: HistoryAction): string {
        return HistoryAction[value] || 'Unknown';
    }
}