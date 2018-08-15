import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { MainComponent } from './containers/main/main.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ValuesComponent } from './components/values/values.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    HomeComponent,
    ValuesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: '', component: MainComponent, children: [
          { path: '', component: HomeComponent, pathMatch: 'full' },
          { path: 'values', component: ValuesComponent }
        ]
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
