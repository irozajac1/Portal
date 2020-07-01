import { Component, OnInit } from '@angular/core';
import { LiteratureService } from 'src/app/shared/literature.service';
import { DetailService } from 'src/app/shared/detail.service';
import { Literature } from 'src/app/shared/message-detail.model';
import { faDownload } from "node_modules/@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-literature',
  templateUrl: './literature.component.html',
  styleUrls: ['./literature.component.css']
})
export class LiteratureComponent implements OnInit {

  faDownload = faDownload;

  constructor(public LiteratureService: LiteratureService, public DetailService: DetailService) { }
  Literatures: Literature[];

  ngOnInit() {
    this.LiteratureService.getLiterature().subscribe(data => this.Literatures = data as Literature[]);
  }

  download(ref) {
    return this.DetailService.downloadFile(ref);
  }

}
