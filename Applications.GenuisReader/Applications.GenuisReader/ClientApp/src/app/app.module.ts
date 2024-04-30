import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AppComponent } from "./app.component";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { HomeModule } from "./components/home/home.module";
import { RouterLink, RouterLinkActive, RouterOutlet, provideRouter } from "@angular/router";
import { routes } from "./app.routing";
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
    declarations: [AppComponent],
    imports: [ BrowserModule, CommonModule, HomeModule, HttpClientModule, RouterLink, RouterLinkActive, RouterOutlet ],
    providers: [provideRouter(routes), provideAnimationsAsync()],
    bootstrap: [AppComponent]
})
export class AppModule { }