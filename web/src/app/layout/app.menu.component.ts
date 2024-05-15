import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html',
})
export class AppMenuComponent implements OnInit {
    model: any[] = [];

    constructor(public layoutService: LayoutService) {}

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [
                    {
                        label: 'Панели асбобҳо',
                        icon: 'pi pi-fw pi-home',
                        routerLink: ['/'],
                    },
                    {
                        label: 'Шаблонҳо',
                        icon: 'pi pi-fw pi-desktop',
                        routerLink: ['/template'],
                    },
                ],
            },
        ];
    }
}
