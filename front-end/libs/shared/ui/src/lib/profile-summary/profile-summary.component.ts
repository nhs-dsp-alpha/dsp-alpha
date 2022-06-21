import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserInfo } from '@front-end/shared/authentication';
import { IParamsSummaryList } from '../nhs-front-end';

@Component({
  selector: 'front-end-profile-summary',
  templateUrl: './profile-summary.component.html',
  styleUrls: ['./profile-summary.component.scss']
})
export class ProfileSummaryComponent {
  @Output()
  photoChange = new EventEmitter();
  @Output()
  nameChange = new EventEmitter();
  @Output()
  emailChange = new EventEmitter();

  @Input() user: UserInfo | undefined

  private photoTag = 'photo';
  private nameTag = 'name';
  private emailTag = 'email';

  constructor() {
    console.log();
  }


  public get params(): IParamsSummaryList {
    return this.user ? {
      rows: [
        {
          key: { text: 'Name' },
          value: { text: this.user.name },
          actions: {
            items: [
              {
                href: "#",
                text: "Change",
                visuallyHiddenText: "name",
                clickable: true,
                tag: this.nameTag
              }
            ]
          }
        },
        {
          key: { text: 'Email address' },
          value: { text: this.user.email },
          actions: {
            items: [
              {
                href: "#",
                text: "Change",
                visuallyHiddenText: "name",
                clickable: true,
                tag: this.emailTag
              }
            ]
          }
        }
      ]
    } : {
      rows: []
    };
  }

  onClicked(tag: string) {
    switch (tag) {
      case this.photoTag:
        this.photoChange.emit();
        break;

      case this.nameTag:
        this.nameChange.emit();
        break;

      case this.emailTag:
        this.emailChange.emit();
        break;

      default:
        break;
    }
  }
}
