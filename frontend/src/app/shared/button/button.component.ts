import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "app-button",
    templateUrl: "button.component.html",
    styleUrls: ["./button.component.css", "./button-variants.component.css"]
})
export class ButtonComponent {
    @Input() className: string = "";
    @Input() iconName?: string;
    @Input() fullwidth: boolean = false;
    @Input() size: "sm" | "md" | "lg" = "md";
    @Input() variant: "contained" | "outlined" | "text" = "contained";
    @Input() disabled: boolean = false;
    @Output() onClick = new EventEmitter<Event>();

    getClass(): string {
        return [
            "common", 
            this.variant, 
            this.size, 
            this.fullwidth ? "fullwidth" : "", 
            this.className
        ].join(" ").trim();
    }
}