import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsPagination } from '../../model/iparams-pagination';

@Component({
  selector: 'nhs-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PaginationComponent implements OnInit {
  @Input() params!: IParamsPagination;
  
  constructor() {
    this.params = {
      previousUrl: "#",
      previousPage: "Treatments",
      nextUrl: "#",
      nextPage: "Symptoms"
    }
  }

  ngOnInit(): void {
  }
}
