import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BackgroundLayoutComponent } from '../shared/components/background-layout/background-layout.component';
import { AssigntmentParticipantComponent } from './pages/assigntment-participant/assigntment-participant.component';
import { CreateUserComponent } from './pages/create-user/create-user.component';
import { ReferredNutritionistComponent } from './pages/referred-nutritionist/referred-nutritionist.component';
import { SearchContactComponent } from './pages/search-contact/search-contact.component';
import { SearchUserComponent } from './pages/search-user/search-user.component';

const routes: Routes = [
  { path: '', children: 
        [
            { path: 'createUser', component: CreateUserComponent},
            { path: 'searchUser', component: SearchUserComponent},
            { path: 'searchContact', component: SearchContactComponent},
            { path: 'referredNutritionist', component: ReferredNutritionistComponent},
            { path: 'assignmentParticipant', component: AssigntmentParticipantComponent}
        ]
  },
  {
    path: '**',
    redirectTo: '/main/createUser',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }