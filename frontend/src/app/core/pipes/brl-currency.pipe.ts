import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'brlCurrency'
})
export class BrlCurrencyPipe implements PipeTransform {
    transform(value: number | string, locale: string = 'pt-BR'): string {
        if (value === null || value === undefined || isNaN(Number(value))) {
            return 'R$ 0,00';
        }

        return new Intl.NumberFormat(locale, {
            style: 'currency',
            currency: 'BRL',
            minimumFractionDigits: 2
        }).format(Number(value));
    }
}