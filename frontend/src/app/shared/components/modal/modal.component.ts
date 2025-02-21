import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.css']
})
export default class ModalComponent {
    
    @Input() 
    isOpen: boolean = false;
    
    @Output() 
    close = new EventEmitter<void>();

    onClose() {
        this.close.emit();
    }
}