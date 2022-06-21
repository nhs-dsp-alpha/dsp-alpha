import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable()
export class CredentialTypesService {

    credentialTypes: CredentialType[];

    constructor() {
        this.credentialTypes = [
            {
                friendlyName: 'Person Identity',
                credentialType: 'PrimaryIdentityCredential',
                credentialIssuer: 'PostOffice',
                enabled: true
            },
            {
                friendlyName: 'HR Record',
                credentialType: '',
                credentialIssuer: '',
                enabled: false
            },
            {
                friendlyName: 'Right to work',
                credentialType: '',
                credentialIssuer: '',
                enabled: false
            },
            {
                friendlyName: 'DBS status',
                credentialType: '',
                credentialIssuer: '',
                enabled: false
            },
            {
                friendlyName: 'Professional registration',
                credentialType: '',
                credentialIssuer: '',
                enabled: false
            },
            {
                friendlyName: 'Employment reference',
                credentialType: '',
                credentialIssuer: '',
                enabled: false
            },
        ]
    }

    public getCredentialTypes(): Observable<CredentialType[]> {
        return of(this.credentialTypes);
    }
}

export interface CredentialType {
    friendlyName: string;
    credentialType: string;
    credentialIssuer: string;
    enabled: boolean;
}