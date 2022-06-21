import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { issuing } from '@front-end/shared/services';
import { IParamsTable } from '@front-end/shared/ui';
import { Observable } from 'rxjs';

@Component({
  templateUrl: './connection-requests.component.html',
  styleUrls: ['./connection-requests.component.scss']
})
export class ConnectionRequestsComponent implements OnInit {
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
    private service: issuing.IssuingService) {
    this.params = this._params;
  }

  ngOnInit(): void {
    this.requests$ = this.service.getPending();
    this.requests$.subscribe(requests => {
      this.setParams(requests.concat(this.service.changedRequests));
    });
  }

  setParams(requests: issuing.ConnectionRequest[]) {
    const rows = requests.map(r => {
      return [
        { text: r.displayName },
        { text: this.datePipe.transform(r.receivedAt, 'MMM d, y, h:mm a')?.toString() },
        { text: r.status?.toString() }, r.status === issuing.ConnectionRequestStatus.Accepted ? {} :
          { text: "Accept", clickable: true, tag: r.id?.toString(), format: "clickable" },
      ]
    });

    const params = this._params;
    params.rows = rows;

    this.params = params;
  }

  onTableCellClicked(tag: string) {
    this.service.updateStatus(parseInt(tag), issuing.ConnectionRequestStatus.Accepted)
      .then((value: issuing.ConnectionRequest) => {
        console.log("Updated", value);
      });
  }
}
