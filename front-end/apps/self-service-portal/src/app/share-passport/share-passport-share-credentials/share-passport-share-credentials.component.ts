import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { credentialTypes } from '@front-end/shared/services';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-share-passport-share-credentials',
  templateUrl: './share-passport-share-credentials.component.html',
  styleUrls: ['./share-passport-share-credentials.component.css']
})
export class SharePassportShareCredentialsComponent implements OnInit {
  @Output()
  public selectedCredentials = new EventEmitter<credentialTypes.CredentialType[]>();
  @Output()
  public messageOutput = new EventEmitter<string>();
  @Output()
  public reVerify = new EventEmitter<boolean>();
  @Output()
  public cancel = new EventEmitter<boolean>();
  @Input()
  public messageInput = '';
  @Input()
  public credentialsSelectedPreviously: credentialTypes.CredentialType[] = [];

  public credentialsSelected: credentialTypes.CredentialType[] = [];

  public selected = false;

  public message = '';

  public credentialTypes?: credentialTypes.CredentialType[];
  public credentialTypesWithSelection?: checkedCredentials[];

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  constructor(private credTypes: credentialTypes.CredentialTypesService) {
  }

  ngOnInit(): void {
    // Get credential types
    this.credTypes.getCredentialTypes().subscribe(
      res => {
        this.credentialTypes = res;
      });

    // set message
    this.message = this.messageInput;

    // Set previously selected credentials
    if (this.credentialsSelectedPreviously.length > 0) {
      this.selected = true;
      this.credentialsSelected = this.credentialsSelectedPreviously;
    }
    this.credentialTypesWithSelection = this.credentialTypes?.map((credType) => {
      return {
        friendlyName: credType.friendlyName,
        credentialType: credType.credentialType,
        credentialIssuer: credType.credentialIssuer,
        enabled: credType.enabled,
        isSelected: this.credentialsSelectedPreviously.some((item) => item.credentialType === credType.credentialType && item.credentialIssuer === credType.credentialIssuer)
      }
    })
  }



  onCheckboxSelect(type: credentialTypes.CredentialType, event: any) {
    if (event.target.checked === true) {
      this.credentialsSelected.push(type);
    }
    else {
      this.credentialsSelected = this.credentialsSelected.filter((item) => item !== type);
    }

    this.selected = this.credentialsSelected.length > 0;
  }

  done() {
    this.selectedCredentials.emit(this.credentialsSelected);
    this.messageOutput.emit(this.message);

    if (this.credentialsSelected !== this.credentialsSelectedPreviously) {
      this.reVerify.emit(true);
    }
    else {
      this.reVerify.emit(false);
    }

  }

  goBack() {
    this.cancel.emit(true);
    return false;
  }
}


export interface checkedCredentials extends credentialTypes.CredentialType {
  isSelected: boolean;
}