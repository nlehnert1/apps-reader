import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AppComponent } from "./app.component";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { HomeModule } from "./components/home/home.module";

@NgModule({
    declarations: [AppComponent],
    imports: [ BrowserModule, CommonModule, HomeModule, HttpClientModule ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }