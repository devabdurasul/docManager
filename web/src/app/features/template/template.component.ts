import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { EditorModule } from '@tinymce/tinymce-angular';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { CheckboxModule } from 'primeng/checkbox';
import { ChipModule } from 'primeng/chip';
import { ChipsModule } from 'primeng/chips';
import { ColorPickerModule } from 'primeng/colorpicker';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputMaskModule } from 'primeng/inputmask';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { KnobModule } from 'primeng/knob';
import { ListboxModule } from 'primeng/listbox';
import { MultiSelectModule } from 'primeng/multiselect';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { ProgressBarModule } from 'primeng/progressbar';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RatingModule } from 'primeng/rating';
import { RippleModule } from 'primeng/ripple';
import { SelectButtonModule } from 'primeng/selectbutton';
import { SidebarModule } from 'primeng/sidebar';
import { SliderModule } from 'primeng/slider';
import { Table, TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { TooltipModule } from 'primeng/tooltip';
import { Customer, DocTemplate, Representative } from 'src/app/demo/api/customer';
import { Product } from 'src/app/demo/api/product';
import { OverlaysDemoRoutingModule } from 'src/app/demo/components/uikit/overlays/overlaysdemo-routing.module';
import { TableDemoRoutingModule } from 'src/app/demo/components/uikit/table/tabledemo-routing.module';
import { CustomerService } from 'src/app/demo/service/customer.service';
import { ProductService } from 'src/app/demo/service/product.service';

@Component({
    selector: 'app-template',
    standalone: true,
    imports: [
        EditorModule,
        TableDemoRoutingModule,
        FormsModule,
        TableModule,
        RatingModule,
        ButtonModule,
        SliderModule,
        InputTextModule,
        ToggleButtonModule,
        RippleModule,
        MultiSelectModule,
        DropdownModule,
        ProgressBarModule,
        ToastModule,
        OverlaysDemoRoutingModule,
        ToastModule,
        DialogModule,
        FormsModule,
        TooltipModule,
        InputTextModule,
        ButtonModule,
        OverlayPanelModule,
        TableModule,
        ConfirmDialogModule,
        SidebarModule,
        RippleModule,
        ConfirmPopupModule,
        InputTextareaModule,
        InputGroupModule,
        InputGroupAddonModule,
        AutoCompleteModule,
        CalendarModule,
        ChipsModule,
        DropdownModule,
        InputMaskModule,
        InputNumberModule,
        ColorPickerModule,
        CascadeSelectModule,
        MultiSelectModule,
        ToggleButtonModule,
        SliderModule,
        InputTextareaModule,
        RadioButtonModule,
        InputTextModule,
        RatingModule,
        ChipModule,
        KnobModule,
        InputSwitchModule,
        ListboxModule,
        SelectButtonModule,
        CheckboxModule,
        ButtonModule,
        InputGroupModule,
        InputGroupAddonModule,
        ReactiveFormsModule,
    ],
    providers: [MessageService, ConfirmationService],
    templateUrl: './template.component.html',
    styleUrl: './template.component.scss',
})
export class TemplateComponent {
    display: boolean = false;
    customers3: DocTemplate[] = [];

    loading: boolean = true;
    templates: DocTemplate[] = [];

    @ViewChild('filter') filter!: ElementRef;

    form = new FormGroup({
        name: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
        file: new FormControl('', Validators.required),
    });

    constructor(
        private customerService: CustomerService,
        private productService: ProductService
    ) {}

    ngOnInit() {
        this.customerService.getDocTemplates().then((customers) => {
            this.templates = [...customers];
            this.customers3 = customers;
            this.setLocalStorage(this.templates);
        });
    }

    setLocalStorage(data) {
        return localStorage.setItem('template', JSON.stringify(data));
    }

    getLocalStorage() {
        return JSON.parse(localStorage.getItem('template'));
    }

    formatCurrency(value: number) {
        return value.toLocaleString('en-US', {
            style: 'currency',
            currency: 'USD',
        });
    }

    onGlobalFilter(table: Table, event: Event) {
        table.filterGlobal(
            (event.target as HTMLInputElement).value,
            'contains'
        );
    }

    clear(table: Table) {
        table.clear();
        this.filter.nativeElement.value = '';
    }

    onSave() {
        let id = this.customers3.length + 1;
        const data = { id, ...this.form.value };

        this.templates.push(data);
        this.setLocalStorage(this.templates);
        this.customers3 = this.getLocalStorage();
        this.display = false;
        this.form.reset();
    }
}
