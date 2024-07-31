export interface User {
    userId: number;
    firstName: string;
    lastName: string;
    email: string;
    isActive: boolean;
    isDeleted: boolean;
    dateCreated: Date;
}