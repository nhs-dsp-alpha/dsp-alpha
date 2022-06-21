import { Component, OnInit } from '@angular/core';
import { organisations } from '@front-end/shared/services';

@Component({
  selector: 'front-end-organisations',
  templateUrl: './organisations.component.html',
  styleUrls: ['./organisations.component.scss']
})
export class OrganisationsComponent implements OnInit {

  constructor(private service:organisations.OrganisationsService) { }

  ngOnInit(): void {
    this.service.getList();
  }

  public get organisations$() {
    return this.service.organisations$;
  }
}
