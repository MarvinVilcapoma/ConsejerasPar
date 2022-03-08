import { NgModule ,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutingModule } from './main-routing.module';
import { SearchUserComponent } from './pages/search-user/search-user.component';
import { SearchContactComponent } from './pages/search-contact/search-contact.component';
import { ReferredNutritionistComponent } from './pages/referred-nutritionist/referred-nutritionist.component';
import { AssigntmentParticipantComponent } from './pages/assigntment-participant/assigntment-participant.component';


@NgModule({
  declarations: [
    SearchUserComponent,
    SearchContactComponent,
    ReferredNutritionistComponent,
    AssigntmentParticipantComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MainModule { }
