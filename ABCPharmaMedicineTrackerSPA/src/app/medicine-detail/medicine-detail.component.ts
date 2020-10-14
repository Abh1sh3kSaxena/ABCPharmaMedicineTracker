import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MedicineDataService } from '../Service/medicine-data.service';
import { Medicine } from '../model/medicine';

@Component({
  selector: 'app-medicine-detail',
  templateUrl: './medicine-detail.component.html',
  styleUrls: ['./medicine-detail.component.scss']
})
export class MedicineDetailComponent implements OnInit {
  detail : Medicine;
  error : boolean = false;
  constructor(private route : ActivatedRoute,
    private _medicineservice : MedicineDataService) {

      this._medicineservice.getMedicineDetail().then(value => {
        this.detail = value;
      }).catch(error => {
        this.error = true;
      });
     }

  ngOnInit(): void {
   
    
  }

}
