import { Component, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { v4 as uuid } from 'uuid';

@Component({
    selector: 'app-input',
    templateUrl: './input.component.html',
    styleUrls: ["input.component.css"],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => InputComponent),
            multi: true
        }
    ]
})
export class InputComponent implements ControlValueAccessor {
    @Input() id: string = uuid();
    @Input() label: string = '';
    @Input() helperText: string = '';
    @Input() type: string = 'text';
    @Input() disabled: boolean = false;
    @Input() className: string = '';
    @Input() value: string = '';
    @Input() error: boolean = false;

    onChange = (value: string) => {};
    onTouched = () => {};

    writeValue(value: string): void {
        this.value = value;
    }

    registerOnChange(fn: any): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: any): void {
        this.onTouched = fn;
    }

    handleInput(event: Event): void {
        const target = event.target as HTMLInputElement;
        this.value = target.value;
        this.onChange(this.value);
    }
}