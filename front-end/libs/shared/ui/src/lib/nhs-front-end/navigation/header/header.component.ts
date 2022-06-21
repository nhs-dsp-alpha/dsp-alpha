import { Component, OnInit, ChangeDetectionStrategy, Input, EventEmitter, Output } from '@angular/core';
import { IParamsHeader } from '../../model/iparams-header';

@Component({
  selector: 'nhs-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements OnInit {
  @Input() params!: IParamsHeader;
  @Input() showAuthentication: boolean = false;
  @Input() isAuthenticated: boolean = false;
  @Input() userName!: string;

  @Output() loginClicked = new EventEmitter<boolean>(); 
  @Output() logoutClicked = new EventEmitter<boolean>(); 

  showNav: boolean = false;
  showAuth: boolean = false;
  showSearch: boolean = false;
  baseUrl = '';
  public menuActive = false;

  constructor() {
  }

  ngOnInit(): void {
    this.showNav = !!this.params?.showNav;
    this.showSearch = !!this.params?.showSearch;

    this.showAuth = this.showAuthentication;
  }

  toggleMenu() {
    this.menuActive = !this.menuActive;
  }

  closeMenu() {
    this.menuActive = false;
  }

  login() {
    console.log("Login clicked");
    this.loginClicked.emit();
  }

  logout() {
    console.log("Logout clicked");
    this.logoutClicked.emit();
  }
}
