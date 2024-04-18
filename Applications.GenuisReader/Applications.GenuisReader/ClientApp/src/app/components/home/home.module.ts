import { NgModule } from "@angular/core";
import { HomeComponent } from "./home.component";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { SeriesService } from "../../services/series.service";
import { SeriesSummaryModule } from "../series-summary/series-summary.module";
import { SeriesDetailsModule } from "../series-details/series-details.module";

@NgModule({
    imports: [CommonModule, HttpClientModule, SeriesSummaryModule, SeriesDetailsModule],
    declarations: [ HomeComponent ],
    exports: [ HomeComponent ],
    providers: [SeriesService]
})
export class HomeModule { }