import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {map} from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class DocumentService {
    private localStorageKey = 'documentData';

    constructor() { }

    private getDocumentData(): any {
        const data = localStorage.getItem(this.localStorageKey);
        return data ? JSON.parse(data) : { departments: [], documents: [] };
    }

    private setDocumentData(data: any): void {
        localStorage.setItem(this.localStorageKey, JSON.stringify(data));
    }

    getDepartments(): Observable<string[]> {
        const data = this.getDocumentData();
        return of(data.departments);
    }

    getDocuments(): Observable<any[]> {
        const data = this.getDocumentData();
        return of(data.documents);
    }

    getTemplates(): Observable<any[]> {
        const templates = localStorage.getItem('template');
        return of(templates ? JSON.parse(templates) : []);
    }

    addDocument(document: any): Observable<any> {
        const data = this.getDocumentData();
        data.documents.push(document);
        this.setDocumentData(data);
        return of(true); // Simulated success response
    }

    deleteDocumentByGuid(guid: any): Observable<any> {
        const data = this.getDocumentData();
        const index = data.documents.findIndex(doc => doc.docId === guid);
        if (index !== -1) {
            data.documents.splice(index, 1);
            this.setDocumentData(data);
            return of(true); // Simulated success response
        }
        return of(false); // Document not found
    }

    addDepartment(department: string): Observable<any> {
        const data = this.getDocumentData();
        data.departments.push(department);
        this.setDocumentData(data);
        return of(true); // Simulated success response
    }

    deleteDepartment(department: string): Observable<any> {
        const data = this.getDocumentData();
        const index = data.departments.indexOf(department);
        if (index !== -1) {
            data.departments.splice(index, 1);
            this.setDocumentData(data);
            return of(true); // Simulated success response
        }
        return of(false); // Department not found
    }

    moveDocumentToDepartment(guid: any, targetDepartment: string): Observable<any> {
        const data = this.getDocumentData();
        const index = data.documents.findIndex(doc => doc.docId === guid);
        if (index !== -1) {
            data.documents[index].department = targetDepartment;
            this.setDocumentData(data);
            return of(true); // Simulated success response
        }
        return of(false); // Document not found
    }

    getNextDepartment(currentDepartment: string): Observable<string> {
        return this.getDepartments().pipe(
            map(departments => {
                const currentIndex = departments.indexOf(currentDepartment);
                if (currentIndex !== -1 && currentIndex < departments.length - 1) {
                    return departments[currentIndex + 1];
                }
                return null; // No next department found
            })
        );
    }
}
