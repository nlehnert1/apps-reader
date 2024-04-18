import { NgModule } from "@angular/core";
import { HomeComponent } from "./home.component";
import { CommonModule } from "@angular/common";
import { SeriesSummaryComponent } from "./series-summary/series-summary.component";
import { HttpClientModule } from "@angular/common/http";
import { SeriesService } from "./series-summary/series-summary.service";

@NgModule({
    imports: [CommonModule, HttpClientModule],
    declarations: [ HomeComponent, SeriesSummaryComponent ],
    exports: [ HomeComponent ],
    providers: [SeriesService]
})
export class HomeModule { }