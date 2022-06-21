/**
 * Api.Issuing
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { CredentialStatus } from './credentialStatus';
import { Presentation } from './presentation';
import { StaffMember } from './staffMember';

export interface Credential { 
    id?: number;
    data: string;
    status?: CredentialStatus;
    createdDate?: Date;
    issuedDate?: Date;
    sourceOrganisation?: string;
    staffMemberId?: number;
    staffMember?: StaffMember;
    presentations?: Array<Presentation>;
}