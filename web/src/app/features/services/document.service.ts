import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

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
}
