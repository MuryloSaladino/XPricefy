import { Component, Input, HostBinding } from '@angular/core';

@Component({
    selector: 'app-icon',
    template: `<span>{{ name }}</span>`,
    styleUrls: ['./icon.component.css']
})
export class IconComponent {
    @Input() name!: string;
    @Input() size: 'sm' | 'md' | 'lg' | 'inherit' = 'inherit';
    @Input() className: string = '';

    @HostBinding('class') get classes(): string {
        return `material-symbols-sharp icon ${this.size} ${this.className}`;
    }
}