import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'app-avatar',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.css']
})
export class AvatarComponent implements OnInit {

    @Input() username!: string; 
    avatarLetters: string = '';
    backgroundColor: string = ''; 

    ngOnInit() {
        this.avatarLetters = this.username.slice(0, 2).toUpperCase();
        this.backgroundColor = this.generateBackgroundColor(this.username);
    }

    private generateBackgroundColor(name: string): string {
        let hash = 0;
        for (let i = 0; i < name.length; i++) {
            hash = name.charCodeAt(i) + ((hash << 5) - hash);
        }

        const color = `rgb(${(hash & 0xFF0000) >> 16}, ${(hash & 0x00FF00) >> 8}, ${hash & 0x0000FF})`;
        return color;
    }
}