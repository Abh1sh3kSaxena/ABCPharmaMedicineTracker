import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MedicineDataService {

  constructor(private http : HttpClient) { }

  public async getAllMedicine() : Promise<any>{
    return await this.http.get('http://localhost:61418/api/medicine').toPromise();
  }
}
