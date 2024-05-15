import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';

import { Customer } from '../demo/api/customer';
import { CustomerService } from '../demo/service/customer.service';
import { ProductService } from '../demo/service/product.service';
import { AuthService } from '../features/auth/services/auth.service';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html',
    providers: [MessageService, ConfirmationService],
})
export class AppTopBarComponent implements OnInit {
    items!: MenuItem[];

    langItems: MenuItem[] = [];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    isOpen: boolean = false;

    constructor(
        public layoutService: LayoutService,
        public authService: AuthService,
        private router: Router,
        private customerService: CustomerService,
        private productService: ProductService
    ) {}

    signOut(): void {
        this.authService.logout();
        this.router.navigate(['/login'], { skipLocationChange: true });
    }

    openLang() {
        return (this.isOpen = !this.isOpen);
    }

    ngOnInit(): void {
        this.langItems = [
            { label: 'Update', icon: 'pi pi-refresh' },
            { label: 'Delete', icon: 'pi pi-times' },
            {
                label: 'Angular.io',
                icon: 'pi pi-info',
                url: 'http://angular.io',
            },
            { separator: true },
            { label: 'Setup', icon: 'pi pi-cog' },
        ];
    }
}
