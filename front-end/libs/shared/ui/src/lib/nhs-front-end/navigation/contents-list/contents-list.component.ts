import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsContentsList } from '../../model/iparams-contents-list';

@Component({
  selector: 'nhs-contents-list',
  templateUrl: './contents-list.component.html',
  styleUrls: ['./contents-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContentsListComponent implements OnInit {
  @Input() params!: IParamsContentsList;

  constructor() {
    this.params = {
      items: [
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/",
          text: "What is AMD?",
          current: true
        },
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/symptoms/",
          text: "Symptoms"
        },
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/getting-diagnosed/",
          text: "Getting diagnosed"
        }
        ,
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/treatment/",
          text: "Treatments"
        }
        ,
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/living-with-amd/",
          text: "Living with AMD"
        }
      ]
    }
  }

  ngOnInit(): void {
  }
}
