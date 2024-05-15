import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor() {
        // Check if initial users exist in local storage, if not, create them
        const adminExists = localStorage.getItem('admin');
        if (!adminExists) {
            localStorage.setItem('admin', JSON.stringify({
                username: 'admin',
                password: 'password',
                role: 'admin'
            }));
        }

        const operatorExists = localStorage.getItem('operator');
        if (!operatorExists) {
            localStorage.setItem('operator', JSON.stringify({
                username: 'operator',
                password: 'password',
                role: 'operator'
            }));
        }

        const employeeExists = localStorage.getItem('employee');
        if (!employeeExists) {
            localStorage.setItem('employee', JSON.stringify({
                username: 'employee',
                password: 'password',
                role: 'employee'
            }));
        }
    }

    login(username: string, password: string): boolean {
        // Perform fake authentication logic
        const user = localStorage.getItem(username);
        if (user) {
            const parsedUser = JSON.parse(user);
            if (parsedUser.password === password) {
                // Store authentication status in local storage
                localStorage.setItem('currentUser', JSON.stringify({
                    username: parsedUser.username,
                    role: parsedUser.role
                }));
                return true;
            }
        }
        return false;
    }

    logout(): void {
        // Clear authentication status from local storage
        localStorage.removeItem('currentUser');
    }

    isAuthenticated(): boolean {
        // Check if user is authenticated by inspecting local storage
        return !!localStorage.getItem('currentUser');
    }

    getUserRole(): string | null {
        // Get user role from local storage
        const currentUser = localStorage.getItem('currentUser');
        if (currentUser) {
            const user = JSON.parse(currentUser);
            return user.role;
        }
        return null;
    }


    getUserName(): string | null {
        // Get user role from local storage
        const currentUser = localStorage.getItem('currentUser');
        if (currentUser) {
            const user = JSON.parse(currentUser);
            return user.username;
        }
        return null;
    }
}
