import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { StyleClassModule } from 'primeng/styleclass';

@Component({
    standalone: true,
    selector: 'app-card',
    templateUrl: './card.component.html',
    imports: [CommonModule, StyleClassModule],
})
export class CardComponent {}
