import { NgModule ,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutingModule } from './main-routing.module';
import { SearchUserComponent } from './pages/search-user/search-user.component';
import { SearchContactComponent } from './pages/search-contact/search-contact.component';
import { ReferredNutritionistComponent } from './pages/referred-nutritionist/referred-nutritionist.component';
import { AssigntmentParticipantComponent } from './pages/assigntment-participant/assigntment-participant.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';
import { CreateUserComponent } from './pages/create-user/create-user.component';
import { FilterPipe } from './pipes/filter.pipe';

@NgModule({
  declarations: [
    SearchUserComponent,
    SearchContactComponent,
    ReferredNutritionistComponent,
    AssigntmentParticipantComponent,
    CreateUserComponent,
    FilterPipe
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    NgxPaginationModule,
    FormsModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MainModule { }
