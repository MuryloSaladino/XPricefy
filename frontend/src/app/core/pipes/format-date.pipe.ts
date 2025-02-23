import { Pipe, PipeTransform } from "@angular/core";
import * as dayjs from "dayjs";

@Pipe({
    name: "formatDate"
})
export class FormatDatePipe implements PipeTransform {
    transform(date: string | Date) {
        return dayjs(date).format("DD/MM/YYYY")
    }
}