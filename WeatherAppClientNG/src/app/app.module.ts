import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MdToolbarModule } from '@angular/material';

import { AppComponent } from './app.component';
import { QueryComponent } from './query/query.component';

@NgModule({
  declarations: [
    AppComponent,
    QueryComponent
  ],
  imports: [
    BrowserModule,
    MdToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
