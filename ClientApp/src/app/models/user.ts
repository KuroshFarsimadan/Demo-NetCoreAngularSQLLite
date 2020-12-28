import { Image } from './image';

export interface User {
    id: number;
    userName: string;
    errors: string;
    token: string;
    password: string;
    sex: string;
    detailedProfile: string;
    preferredCompany: string;
    hobbies: string;
    locationCity: string;
    locationCountry: string;
    age: number;
    images: Image[];
    creationDate: Date;
    lastActiveDate: Date
}

