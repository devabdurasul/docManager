import { Component, OnInit } from '@angular/core';
import {DocumentService} from "../../../features/services/document.service";

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
    departments: string[] = [];
    documents: any[] = [];
    newDepartment: string;
    docName: string;
    docContent: any;
    display: boolean = false;

    selectedDepartment: any;

    constructor(private documentService: DocumentService) { }

    ngOnInit(): void {
        this.fetchDocuments();
        this.fetchDepartments();
    }

    fetchDocuments() {
        this.documentService.getDocuments().subscribe(
            documents => {
                this.documents = documents;
            },
            error => {
                console.error('Error fetching documents:', error);
            }
        );
    }

    fetchDepartments() {
        this.documentService.getDepartments().subscribe(
            departments => {
                this.departments = departments;
            },
            error => {
                console.error('Error fetching departments:', error);
            }
        );
    }

    addDocument(value: any): void {
        this.display = true;
        this.selectedDepartment = value;

    }

    saveDocument(value: any): void {
        this.display = false;
        console.log(this.docContent);

        // this.documentService.addDocument(value);
        // this.fetchDocuments();
    }

    addDepartment(value: string): void {
        this.documentService.addDepartment(value);
        this.fetchDepartments();
    }

    deleteDepartment(value: string): void {
        this.documentService.deleteDepartment(value);
        this.fetchDepartments();
    }
}
