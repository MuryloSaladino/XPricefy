import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'eurCurrency'
})
export class EurCurrencyPipe implements PipeTransform {
    transform(value: number | string, locale: string = 'de-DE'): string {
        if (value === null || value === undefined || isNaN(Number(value))) {
            return '€0,00';
        }

        return new Intl.NumberFormat(locale, {
            style: 'currency',
            currency: 'EUR',
            minimumFractionDigits: 2
        }).format(Number(value));
    }
}