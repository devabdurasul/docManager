import {Component, OnInit} from '@angular/core';
import {DocumentService} from "../../../features/services/document.service";
import {Guid} from "guid-typescript";
import {guid} from "@fullcalendar/core/internal";
import {v4 as uuidv4} from 'uuid';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
    departments: string[] = [];
    documents: any[] = [];
    newDepartment: string;
    docName: string;
    docDescription: string;
    docContent: any;
    display: boolean = false;
    selectedDepartment: any;

    constructor(private documentService: DocumentService) {
    }

    ngOnInit(): void {
        this.fetchDocuments();
        this.fetchDepartments();
    }

    guid2() {
        return uuidv4();
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

    cancel() {
        window.location.reload();
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
        this.documentService.addDocument(value);
        window.location.reload()
        this.fetchDocuments();
    }

    deleteDocument(value: any): void {
        this.documentService.deleteDocumentByGuid(value);
        this.fetchDocuments();
    }

    addDepartment(value: string): void {
        this.documentService.addDepartment(value);
        this.fetchDepartments();
    }

    deleteDepartment(value: string): void {
        this.documentService.deleteDepartment(value);
        this.fetchDepartments();
    }

    public readonly Guid = Guid;
    protected readonly guid = guid;
}
