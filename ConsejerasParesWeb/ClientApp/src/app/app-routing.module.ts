import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BackgroundLayoutComponent } from './modules/shared/components/background-layout/background-layout.component';

const routes: Routes = [
  { path: '', redirectTo: 'auth/signin', pathMatch: 'full'},
  { path: 'auth', loadChildren: ()=> import('./modules/public/public.module').then(m => m.PublicModule) },
  { path: '', component: BackgroundLayoutComponent, children: 
    [
      {path: 'main', loadChildren: ()=> import('./modules/main/main.module').then(m => m.MainModule)}
    ]
  },
  // { path: '**', component: NotFoundComponent }
  { path: '**', redirectTo: 'auth/signin', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
