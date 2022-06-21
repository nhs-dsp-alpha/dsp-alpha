import { HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { CredentialTypesService, CredentialType } from './credential-types.service';

describe('CredentialTypesService', () => {
    let service: CredentialTypesService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
            ],
            providers: [
                CredentialTypesService
            ]
        });
        service = TestBed.inject(CredentialTypesService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should return config', () => {
        const credentialTypes: CredentialType[] = [
            {
                friendlyName: 'Person Identity',
                CredentialType: 'PrimaryIdentityCredential',
                CredentialIssuer: 'PostOffice',
                Enabled: true
            },
            {
                friendlyName: 'HR Record',
                CredentialType: '',
                CredentialIssuer: '',
                Enabled: false
            },
            {
                friendlyName: 'Right to work',
                CredentialType: '',
                CredentialIssuer: '',
                Enabled: false
            },
            {
                friendlyName: 'DBS status',
                CredentialType: '',
                CredentialIssuer: '',
                Enabled: false
            },
            {
                friendlyName: 'Professional registration',
                CredentialType: '',
                CredentialIssuer: '',
                Enabled: false
            },
            {
                friendlyName: 'Employment reference',
                CredentialType: '',
                CredentialIssuer: '',
                Enabled: false
            },
        ];

        service.getCredentialTypes().subscribe((result) => {
            expect(result).toEqual(credentialTypes);
        });
    });
});
