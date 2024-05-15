import { Component, OnInit } from '@angular/core';
import { FormControl, FormControlName, FormGroup } from '@angular/forms';
import { guid } from '@fullcalendar/core/internal';
import { v4 as uuidv4 } from 'uuid';

import { DocumentService } from '../../../features/services/document.service';

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

    form = new FormGroup({
        name: new FormControl(''),
        description: new FormControl(''),
        file: new FormControl(''),
    });

    constructor(private documentService: DocumentService) {}

    ngOnInit(): void {
        this.fetchDocuments();
        this.fetchDepartments();
    }

    guid2() {
        return uuidv4();
    }

    fetchDocuments() {
        this.documentService.getDocuments().subscribe(
            (documents) => {
                this.documents = documents;
            },
            (error) => {
                console.error('Error fetching documents:', error);
            }
        );
    }

    cancel() {
        window.location.reload();
    }

    fetchDepartments() {
        this.documentService.getDepartments().subscribe(
            (departments) => {
                this.departments = departments;
            },
            (error) => {
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
        window.location.reload();
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

    moveDocumentToNextDepartment(documentId: any, currentDepartment: string) {
        this.documentService
            .getNextDepartment(currentDepartment)
            .subscribe((nextDepartment) => {
                if (nextDepartment) {
                    this.documentService
                        .moveDocumentToDepartment(documentId, nextDepartment)
                        .subscribe((success) => {
                            if (success) {
                                console.log(
                                    'Document moved to next department successfully.'
                                );
                            } else {
                                console.error(
                                    'Failed to move document to next department.'
                                );
                            }
                        });
                } else {
                    console.warn('No next department found.');
                }
            });
        this.fetchDocuments();
    }

    protected readonly guid = guid;

    show(id) {
        const data = JSON.parse(localStorage.getItem('template'));
        console.log(data);
        this.form.setValue({
            name: data[id].name,
            description: data[id].description,
            file: data[id].file,
        });
        this.newDepartment = data[id].name;

        this.display = true;
    }
}
