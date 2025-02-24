import { Pipe, PipeTransform } from "@angular/core";
import * as dayjs from "dayjs";

@Pipe({
    name: "formatDate"
})
export class FormatDatePipe implements PipeTransform {
    transform(date: string, format: string = "DD/MM/YYYY") {
        return dayjs(date).format(format)
    }
}