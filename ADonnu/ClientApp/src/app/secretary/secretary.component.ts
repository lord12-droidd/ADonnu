import { Component, OnInit } from '@angular/core';
import { SecretaryService } from '../services/secretary.service';

@Component({
  selector: 'app-secretary',
  templateUrl: './secretary.component.html',
  styleUrls: ['./secretary.component.css']
})
export class SecretaryComponent implements OnInit {
  public approvedIndRequests: any;

  constructor(private service : SecretaryService) { }

  ngOnInit() {
    this.getApprovedIndRequests();
  }

  getApprovedIndRequests() {
    this.service.getApprovedIndRequests().subscribe(
      data => {
        this.approvedIndRequests = data;
        console.log(data);
      }
    );
  }

  downloadApprovedIndRequest(path : string) {

  }

  downloadAdds(path : string) {

  }
}
