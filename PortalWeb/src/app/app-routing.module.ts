import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShowMessageComponent } from './components/show-message/show-message.component';
import { MessagesComponent } from './components/messages/messages.component';
// import { AuthenticationGuard } from 'microsoft-adal-angular6';

const routes: Routes = [
  // { path: '', component: ShowMessageComponent, pathMatch: 'full', canActivate: [AuthenticationGuard] },
  { path: '', component: ShowMessageComponent, pathMatch: 'full' },
  // { path: '**', redirectTo: '' },
  {
    path: '', component: ShowMessageComponent,
    children: [
      { path: 'Messages', component: MessagesComponent },    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
