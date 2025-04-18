import { HttpClientModule, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { GoogleLoginComponent } from './google-login/google-login.component';

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    GoogleLoginComponent],
  providers:
    [provideHttpClient(withInterceptorsFromDi())]
})
export class AppModule { }
