import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {MedicineDataService} from '../Service/medicine-data.service';
import {IMedicine, Medicine} from '../model/medicine';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements AfterViewInit {
_medicine : Medicine[] = null;
  constructor(private _medicineService : MedicineDataService) { }

  displayedColumns: string[] = ['name','brand','price','quantity','expirydate'];
  dataSource:MatTableDataSource<IMedicine>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  async ngAfterViewInit() {
    await this._medicineService.getAllMedicine().then(data =>
      {this._medicine = data}).catch(exception => 
        {
this._medicine = null;
        });
        this.dataSource = new MatTableDataSource(this._medicine);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
  }

  applyFilter(event : Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

}
