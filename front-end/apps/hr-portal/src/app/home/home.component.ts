import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { organisations, issuer } from '@front-end/shared/services';
import { BehaviorSubject, firstValueFrom, map, Observable } from 'rxjs';
import { AuthenticationService, UserInfo } from '@front-end/shared/authentication';
import { ActivatedRoute, Router } from '@angular/router';
import { NhsUserService } from '../services/nhs-user/nhs-user.service';
import { NhsidUserOrgs } from '../services/nhs-user/api';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @Output()
  public hideOrganisation = new EventEmitter<boolean>();
  @Output()
  public loginClicked = new EventEmitter();

  selectedOrganisation?: organisations.Organisation;
  selectedOrganisationId?= '';
  organisationSelected = false;
  hidePortal = true;

  private _organisations$ = new BehaviorSubject<organisations.Organisation[]>([]);

  constructor(
    private organisationsService: organisations.OrganisationsService,
    private authentication: AuthenticationService,
    private userService: NhsUserService,
    private router: Router,
    private route: ActivatedRoute) {
    // 
  }

  public get isAuthenticated(): boolean {
    return this.authentication.isAuthenticated;
  }


  onLoginClicked() {
    this.authentication.login();
  }

  ngOnInit(): void {
    this.hideOrganisation.emit(true);
    this.organisationsService.getList();

    this.userService.getUser().then(user => {
      if (user?.userOrgs) {
        let orgId = 0;
        this._organisations$.next(user?.userOrgs.map(o => {
          return { id: orgId++, code: o.orgCode, name: o.orgName } as organisations.Organisation;
        }));
      }
    });
  }

  // ***************** TODO: *****************
  // This is using the organisations from the User Claims. If we were to support
  // multiple Orgs per App Service, this is probably the say to go.
  // It makes more sense than selecting Organisations from the databaser
  public get organisations$(): Observable<organisations.Organisation[]> {
    return this._organisations$;
    // return this.organisationsService.organisations$.pipe(map(orgs => this.filterOrganisations(orgs)));
  }

  private filterOrganisations(organisations: organisations.Organisation[]) {
    return organisations.filter(o => o.name);
  }

  onOrganisationIdSelected(id: string | undefined) {
    if (id) {
      this.selectedOrganisationId = id;
      firstValueFrom(this.organisations$.pipe(map(orgs => orgs.filter(o => o.id == Number.parseInt(id)))))
        .then(o => {
          this.selectedOrganisation = o.length ? o[0] : undefined;
          this.hideOrganisation.emit(false);
          this.router.navigate(['desktop'])
        });
    }
    else {
      // Clear Organsition
      this.hideOrganisation.emit(true);
    }

  }

  onOrganisationSelected(done: boolean) {
    this.organisationSelected = done;
  }

  onSelectOrganisationBack() {
    // This doesn't work beacuse you can't log out using CIS Mock
    this.authentication.logout();
  }
}
