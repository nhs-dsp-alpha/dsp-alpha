import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { organisations, issuer, container } from '@front-end/shared/services';
import { firstValueFrom, map, Observable } from 'rxjs';

@Component({
  selector: 'self-service-add-organisation',
  templateUrl: './add-organisation.component.html',
  styleUrls: ['./add-organisation.component.css']
})
export class AddOrganisationComponent implements OnInit {
  public photoAdded = false;
  public organisationsFound = false;
  public organisationSelected = false;
  public employeeIdAdded = false;
  public dateOfBirthAdded = false;
  public busy = false;

  selectedOrganisation?: organisations.Organisation;
  selectedOrganisationCode = '';
  photoString = '';
  photoUrl = '';
  employeeId = '';
  dob?: Date;

  constructor(
    private organisationsService: organisations.OrganisationsService,
    private issuerService: issuer.IssuerService,
    private router: Router,
    private containerService: container.ContainerService) {
    //
  }

  ngOnInit(): void {
    this.organisationsService.getList();
  }

  public get organisations$(): Observable<organisations.Organisation[]> {
    return this.organisationsService.organisations$.pipe(map(orgs => this.filterOrganisations(orgs)));
  }

  private filterOrganisations(organisations: organisations.Organisation[]) {
    return organisations.filter(o => o.name);
  }

  async onSummaryContinue(done: boolean) {
    if (done) {
      this.busy = true;
      if (this.photoString !== 'skip') {
        await this.containerService.putProfilePictureBlobPost(this.photoString).then(res => {
          this.photoUrl = res.headers.get("Location") ?? '';
        });
      }

      const sub =
        [
          { key: "employeeId", value: this.employeeId },
          { key: "dob", value: this.dob ? this.dob.toUTCString() : '' }
        ];
      if (this.photoString !== "skip") {
        sub.push({ key: "photoUrl", value: this.photoUrl });
      }
      console.log(sub);
      const request: issuer.ConnectionRequest = { sub, organisationCode: this.selectedOrganisationCode };

      console.log("Connection request...");
      this.issuerService.connect(request)
        .then(() => {
          this.busy = false;
          console.log("Sent");
          this.router.navigateByUrl("/");
        });
    }
  }

  onPhotoAdded(photoString: string) {
    this.photoAdded = true;
    this.photoString = photoString;
  }

  onOrganisationsFound(done: boolean) {
    this.organisationsFound = done;
  }

  onOrganisationCodeSelected(code: string) {
    this.selectedOrganisationCode = code;
    firstValueFrom(this.organisations$.pipe(map(orgs => orgs.filter(o => o.code == code))))
      .then(o => {
        this.selectedOrganisation = o.length ? o[0] : undefined;
      });
  }

  onOrganisationSelected(done: boolean) {
    this.organisationSelected = done;
  }

  onEmployeeIdAdded(employeeId: string) {
    this.employeeId = employeeId;
    this.employeeIdAdded = true;
  }

  onDateOfBirthAdded(dob: Date) {
    this.dob = dob;
    this.dateOfBirthAdded = true;
  }

  onChangePhoto() {
    this.photoAdded = false;
  }

  onChangeOrganisation() {
    this.organisationSelected = false;
  }

  onChangeEmployeeId() {
    this.employeeIdAdded = false;
  }

  onChangeDob() {
    this.dateOfBirthAdded = false;
  }
}
