import {Component, OnInit} from '@angular/core';
import {guid} from "@fullcalendar/core/internal";
import {v4 as uuidv4} from 'uuid';

import { DocumentService } from '../../../features/services/document.service';
import {SelectItem} from "primeng/api";

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

    templates: SelectItem[] = [];
    templatesObj: SelectItem[] = [];

    selectedDrop: SelectItem = { value: '' };

    constructor(private documentService: DocumentService) {
    }

    ngOnInit(): void {
        this.fetchDocuments();
        this.fetchDepartments();
        this.fetchTemplates();
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

    fetchTemplates() {
        this.documentService.getTemplates().subscribe(
            (templates) => {
                console.log(templates);
                templates.forEach((temp) => {
                    this.templates.push(temp.name);
                    this.templatesObj.push(temp);
                    }
                );
            },
            (error) => {
                console.error('Error fetching templates:', error);
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

    populate(){
        if(this.selectedDrop) {
            let templ: any = this.templates.find((t:any) => t.name == this.selectedDrop);
            console.log(templ);
            this.docContent = templ.file;
        }
    }

    moveDocumentToNextDepartment(documentId: any, currentDepartment: string) {
        this.documentService.getNextDepartment(currentDepartment).subscribe(nextDepartment => {
            if (nextDepartment) {
                this.documentService.moveDocumentToDepartment(documentId, nextDepartment).subscribe(success => {
                    if (success) {
                        console.log('Document moved to next department successfully.');
                    } else {
                        console.error('Failed to move document to next department.');
                    }
                });
            } else {
                console.warn('No next department found.');
            }
        });
        this.fetchDocuments();
    }

    protected readonly guid = guid;
}
