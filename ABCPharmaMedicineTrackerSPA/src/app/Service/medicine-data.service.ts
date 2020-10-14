import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Medicine, IMedicine } from '../model/medicine';
import { MedicineDetailComponent } from '../medicine-detail/medicine-detail.component';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MedicineDataService {
  
  constructor(private http : HttpClient) { }

  public async getAllMedicine() : Promise<any>{
    return await this.http.get(environment.API_URL + "api/medicine").toPromise();
  }

  public async getMedicineDetail() : Promise<Medicine>{
    return JSON.parse(localStorage.getItem("medicineDetail"));
   
  }

  public async addMedicineDetail(medicine : Medicine){
    localStorage.setItem("medicineDetail", JSON.stringify(medicine));
  }
}
