import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PlayersComponent } from './players/players.component';
import { PlayerDataService } from './_data-services/player-Data.Service';
import { Interceptor } from './interceptor/app.interceptor.module';
import { AdvertisementDataService } from './_data-services/advertisement-Data.Service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input'
import {MatSelectModule} from '@angular/material/select'
import { MatNativeDateModule } from '@angular/material/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateAdvertisementDialogComponent } from './home/views/create-advertisement-dialog/create-advertisement-dialog.component';
import { GameDataService } from './_data-services/game-Category-Data.Service';
import {MatButtonModule} from '@angular/material/button'
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'
import { RegisterComponent } from './players/register/register.component';
import { LoginComponent } from './players/login/login.component';
import { ConnectDialogComponent } from './home/views/connect-dialog/connect-dialog.component';
import {ClipboardModule} from '@angular/cdk/clipboard';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {MatCheckboxModule} from '@angular/material/checkbox'
import { AvaliateDialogComponent } from './home/views/avaliate-dialog/avaliate-dialog.component';
import { PlayerProfileComponent } from './players/player-profile/player-profile.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PlayersComponent,
    CreateAdvertisementDialogComponent,
    LoginComponent,
    RegisterComponent,
    ConnectDialogComponent,
    AvaliateDialogComponent,
    PlayerProfileComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'players', component: PlayersComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'profile', component: PlayerProfileComponent },
    ]),
    Interceptor,
    BrowserAnimationsModule,
    MatDialogModule,
    MatInputModule,
    MatNativeDateModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    ClipboardModule,
    FontAwesomeModule,
    MatCheckboxModule,
  ],
  providers: [PlayerDataService, AdvertisementDataService, GameDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
