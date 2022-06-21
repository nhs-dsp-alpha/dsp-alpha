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
 *//* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from '../encoder';

import { Observable }                                        from 'rxjs';

import { ConnectionRequest } from '../model/connectionRequest';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class ApiIssuingService {

    protected basePath = 'https://bffdevapimanagement.azure-api.net/organisation';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (const consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     * GetAccepted
     * 
     * @param dspOrgCode 
     * @param dspOrgUserId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getAccepted(dspOrgCode: string, dspOrgUserId: string, observe?: 'body', reportProgress?: boolean): Observable<Array<ConnectionRequest>>;
    public getAccepted(dspOrgCode: string, dspOrgUserId: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ConnectionRequest>>>;
    public getAccepted(dspOrgCode: string, dspOrgUserId: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ConnectionRequest>>>;
    public getAccepted(dspOrgCode: string, dspOrgUserId: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (dspOrgCode === null || dspOrgCode === undefined) {
            throw new Error('Required parameter dspOrgCode was null or undefined when calling getAccepted.');
        }

        if (dspOrgUserId === null || dspOrgUserId === undefined) {
            throw new Error('Required parameter dspOrgUserId was null or undefined when calling getAccepted.');
        }

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});

        let headers = this.defaultHeaders;
        if (dspOrgCode !== undefined && dspOrgCode !== null) {
            headers = headers.set('dsp-org-code', String(dspOrgCode));
        }
        if (dspOrgUserId !== undefined && dspOrgUserId !== null) {
            headers = headers.set('dsp-org-user-id', String(dspOrgUserId));
        }

        // authentication (apiKeyHeader) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]) {
            headers = headers.set('Ocp-Apim-Subscription-Key', this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]);
        }

        // authentication (apiKeyQuery) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["subscription-key"]) {
            queryParameters = queryParameters.set('subscription-key', this.configuration.apiKeys["subscription-key"]);
        }

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<ConnectionRequest>>('get',`${this.basePath}/accepted`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * GetActive
     * 
     * @param dspOrgCode 
     * @param dspOrgUserId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getActive(dspOrgCode: string, dspOrgUserId: string, observe?: 'body', reportProgress?: boolean): Observable<Array<ConnectionRequest>>;
    public getActive(dspOrgCode: string, dspOrgUserId: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ConnectionRequest>>>;
    public getActive(dspOrgCode: string, dspOrgUserId: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ConnectionRequest>>>;
    public getActive(dspOrgCode: string, dspOrgUserId: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (dspOrgCode === null || dspOrgCode === undefined) {
            throw new Error('Required parameter dspOrgCode was null or undefined when calling getActive.');
        }

        if (dspOrgUserId === null || dspOrgUserId === undefined) {
            throw new Error('Required parameter dspOrgUserId was null or undefined when calling getActive.');
        }

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});

        let headers = this.defaultHeaders;
        if (dspOrgCode !== undefined && dspOrgCode !== null) {
            headers = headers.set('dsp-org-code', String(dspOrgCode));
        }
        if (dspOrgUserId !== undefined && dspOrgUserId !== null) {
            headers = headers.set('dsp-org-user-id', String(dspOrgUserId));
        }

        // authentication (apiKeyHeader) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]) {
            headers = headers.set('Ocp-Apim-Subscription-Key', this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]);
        }

        // authentication (apiKeyQuery) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["subscription-key"]) {
            queryParameters = queryParameters.set('subscription-key', this.configuration.apiKeys["subscription-key"]);
        }

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<ConnectionRequest>>('get',`${this.basePath}/active`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * GetAll
     * 
     * @param dspOrgCode 
     * @param dspOrgUserId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getAll(dspOrgCode: string, dspOrgUserId: string, observe?: 'body', reportProgress?: boolean): Observable<Array<ConnectionRequest>>;
    public getAll(dspOrgCode: string, dspOrgUserId: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ConnectionRequest>>>;
    public getAll(dspOrgCode: string, dspOrgUserId: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ConnectionRequest>>>;
    public getAll(dspOrgCode: string, dspOrgUserId: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (dspOrgCode === null || dspOrgCode === undefined) {
            throw new Error('Required parameter dspOrgCode was null or undefined when calling getAll.');
        }

        if (dspOrgUserId === null || dspOrgUserId === undefined) {
            throw new Error('Required parameter dspOrgUserId was null or undefined when calling getAll.');
        }

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});

        let headers = this.defaultHeaders;
        if (dspOrgCode !== undefined && dspOrgCode !== null) {
            headers = headers.set('dsp-org-code', String(dspOrgCode));
        }
        if (dspOrgUserId !== undefined && dspOrgUserId !== null) {
            headers = headers.set('dsp-org-user-id', String(dspOrgUserId));
        }

        // authentication (apiKeyHeader) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]) {
            headers = headers.set('Ocp-Apim-Subscription-Key', this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]);
        }

        // authentication (apiKeyQuery) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["subscription-key"]) {
            queryParameters = queryParameters.set('subscription-key', this.configuration.apiKeys["subscription-key"]);
        }

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<ConnectionRequest>>('get',`${this.basePath}/`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * GetPending
     * 
     * @param dspOrgCode 
     * @param dspOrgUserId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getPending(dspOrgCode: string, dspOrgUserId: string, observe?: 'body', reportProgress?: boolean): Observable<Array<ConnectionRequest>>;
    public getPending(dspOrgCode: string, dspOrgUserId: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ConnectionRequest>>>;
    public getPending(dspOrgCode: string, dspOrgUserId: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ConnectionRequest>>>;
    public getPending(dspOrgCode: string, dspOrgUserId: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (dspOrgCode === null || dspOrgCode === undefined) {
            throw new Error('Required parameter dspOrgCode was null or undefined when calling getPending.');
        }

        if (dspOrgUserId === null || dspOrgUserId === undefined) {
            throw new Error('Required parameter dspOrgUserId was null or undefined when calling getPending.');
        }

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});

        let headers = this.defaultHeaders;
        if (dspOrgCode !== undefined && dspOrgCode !== null) {
            headers = headers.set('dsp-org-code', String(dspOrgCode));
        }
        if (dspOrgUserId !== undefined && dspOrgUserId !== null) {
            headers = headers.set('dsp-org-user-id', String(dspOrgUserId));
        }

        // authentication (apiKeyHeader) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]) {
            headers = headers.set('Ocp-Apim-Subscription-Key', this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]);
        }

        // authentication (apiKeyQuery) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["subscription-key"]) {
            queryParameters = queryParameters.set('subscription-key', this.configuration.apiKeys["subscription-key"]);
        }

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<ConnectionRequest>>('get',`${this.basePath}/pending`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * GetRejected
     * 
     * @param dspOrgCode 
     * @param dspOrgUserId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getRejected(dspOrgCode: string, dspOrgUserId: string, observe?: 'body', reportProgress?: boolean): Observable<Array<ConnectionRequest>>;
    public getRejected(dspOrgCode: string, dspOrgUserId: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ConnectionRequest>>>;
    public getRejected(dspOrgCode: string, dspOrgUserId: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ConnectionRequest>>>;
    public getRejected(dspOrgCode: string, dspOrgUserId: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (dspOrgCode === null || dspOrgCode === undefined) {
            throw new Error('Required parameter dspOrgCode was null or undefined when calling getRejected.');
        }

        if (dspOrgUserId === null || dspOrgUserId === undefined) {
            throw new Error('Required parameter dspOrgUserId was null or undefined when calling getRejected.');
        }

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});

        let headers = this.defaultHeaders;
        if (dspOrgCode !== undefined && dspOrgCode !== null) {
            headers = headers.set('dsp-org-code', String(dspOrgCode));
        }
        if (dspOrgUserId !== undefined && dspOrgUserId !== null) {
            headers = headers.set('dsp-org-user-id', String(dspOrgUserId));
        }

        // authentication (apiKeyHeader) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]) {
            headers = headers.set('Ocp-Apim-Subscription-Key', this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]);
        }

        // authentication (apiKeyQuery) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["subscription-key"]) {
            queryParameters = queryParameters.set('subscription-key', this.configuration.apiKeys["subscription-key"]);
        }

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<ConnectionRequest>>('get',`${this.basePath}/rejected`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * UpdateStatus
     * 
     * @param dspOrgCode 
     * @param dspOrgUserId 
     * @param id Format - int32.
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public updateStatus(dspOrgCode: string, dspOrgUserId: string, id: number, body?: ConnectionRequest, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public updateStatus(dspOrgCode: string, dspOrgUserId: string, id: number, body?: ConnectionRequest, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public updateStatus(dspOrgCode: string, dspOrgUserId: string, id: number, body?: ConnectionRequest, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public updateStatus(dspOrgCode: string, dspOrgUserId: string, id: number, body?: ConnectionRequest, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (dspOrgCode === null || dspOrgCode === undefined) {
            throw new Error('Required parameter dspOrgCode was null or undefined when calling updateStatus.');
        }

        if (dspOrgUserId === null || dspOrgUserId === undefined) {
            throw new Error('Required parameter dspOrgUserId was null or undefined when calling updateStatus.');
        }

        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling updateStatus.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});

        let headers = this.defaultHeaders;
        if (dspOrgCode !== undefined && dspOrgCode !== null) {
            headers = headers.set('dsp-org-code', String(dspOrgCode));
        }
        if (dspOrgUserId !== undefined && dspOrgUserId !== null) {
            headers = headers.set('dsp-org-user-id', String(dspOrgUserId));
        }

        // authentication (apiKeyHeader) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]) {
            headers = headers.set('Ocp-Apim-Subscription-Key', this.configuration.apiKeys["Ocp-Apim-Subscription-Key"]);
        }

        // authentication (apiKeyQuery) required
        if (this.configuration.apiKeys && this.configuration.apiKeys["subscription-key"]) {
            queryParameters = queryParameters.set('subscription-key', this.configuration.apiKeys["subscription-key"]);
        }

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('put',`${this.basePath}/${encodeURIComponent(String(id))}`,
            {
                body: body,
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
