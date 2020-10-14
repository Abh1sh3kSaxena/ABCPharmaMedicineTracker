import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MedicineDetailComponent } from './medicine-detail/medicine-detail.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';

const routes: Routes = [
  {path : '', component : HomeComponent},
  {path : 'home', component :HomeComponent},
  {path : 'detail/:id', component : MedicineDetailComponent},
  {path : "**", component : PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
