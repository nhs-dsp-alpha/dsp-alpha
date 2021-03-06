/**
 * BFF.HrPortal
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { NhsidNrbacRoles } from './nhsidNrbacRoles';
import { NhsidOrgMemberships } from './nhsidOrgMemberships';
import { NhsidOrgRoles } from './nhsidOrgRoles';
import { NhsidUserOrgs } from './nhsidUserOrgs';

export interface B2CUser { 
    sub?: string;
    nhsidUseruid?: string;
    userOrgMemberships?: Array<NhsidOrgMemberships>;
    gdcId?: string;
    initials?: string;
    gmpId?: string;
    consultantId?: string;
    nhsidOrgRoles?: Array<NhsidOrgRoles>;
    title?: string;
    gmcId?: string;
    displayName?: string;
    givenName?: string;
    uid?: string;
    rcnId?: string;
    nrbacRoles?: Array<NhsidNrbacRoles>;
    userOrgs?: Array<NhsidUserOrgs>;
    nmcId?: string;
    middleNames?: string;
    name?: string;
    idassurancelevel?: string;
    familyName?: string;
    email?: string;
    gphcId?: string;
    gdpId?: string;
}