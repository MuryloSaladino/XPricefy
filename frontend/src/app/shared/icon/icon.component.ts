import { Component, Input, HostBinding, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-icon',
    template: `<span (click)="onClick.emit($event)">{{ name }}</span>`,
    styleUrls: ['./icon.component.css']
})
export class IconComponent {
    @Input() name!: string;
    @Input() size: 'sm' | 'md' | 'lg' | 'inherit' = 'inherit';
    @Input() className: string = '';

    @Output() onClick = new EventEmitter<Event>();

    @HostBinding('class') get classes(): string {
        return `material-symbols-sharp icon ${this.size} ${this.className}`;
    }
}