import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { IParamsTable } from '@front-end/shared/ui';
import { Observable, map } from 'rxjs';
import { Router } from '@angular/router';
import { issuing } from '@front-end/shared/services';

@Component({
  selector: 'hr-portal-view-passports-issue',
  templateUrl: './view-passports-issue.component.html',
  styleUrls: ['./view-passports-issue.component.css']
})
export class ViewPassportsIssueComponent implements OnInit {
  requests$?: Observable<issuing.ConnectionRequest[]>;

  params = this._params;
  private datePipe = new DatePipe('en-GB');

  private get _params(): IParamsTable {
    return {
      // caption: "View digital staff passports", captionClasses: "",
      head: [
        { text: "Full name" },
        { text: "Start date" },
        { text: "	Passport status" },
        { text: "Action" },
      ],
      rows: []
    };
  }

  constructor(
    private service: issuing.IssuingService,
    private router: Router) {
    this.params = this._params;
  }

  ngOnInit(): void {
    this.requests$ = this.service.getAccepted();
    this.requests$.subscribe(requests => {
      this.setParams(requests.concat(this.service.changedRequests));
    });
  }

  setParams(requests: issuing.ConnectionRequest[]) {
    const rows = requests.map(r => {
      return [
        { text: r.displayName },
        { text: this.datePipe.transform(r.receivedAt, 'MMM d, y, h:mm a')?.toString() },
        { text: r.status?.toString() }, r.status === issuing.ConnectionRequestStatus.Accepted ?
          { text: "Issue", clickable: true, tag: r.id?.toString(), format: "clickable" } : {},
      ]
    });

    const params = this._params;
    params.rows = rows;

    this.params = params;
  }
  onTableCellClicked(tag: string) {
    this.requests$ = this.service.getAccepted();

    const result = this.getRequestData(Number(tag))?.subscribe(x => {
      this.router.navigateByUrl(`/view-passports-issue/view-passport/${tag}`, { state: x });
    });


    //const request = { "test": "value" };

    //this.router.navigateByUrl(`/view-passports-issue/view-passport/${tag}`, { state: request });
  }

  getRequestData(tag: number): Observable<issuing.ConnectionRequest | undefined> | undefined {

    // const result = resultsArray.pipe(
    //   map(req => req.find(x => x.id === tag))
    // );
    const result = this.requests$?.pipe(
      map(req => req.find(x => x.id === tag))
    );
    return result;
  }


}
