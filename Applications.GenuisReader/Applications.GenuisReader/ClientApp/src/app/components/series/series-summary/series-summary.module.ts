import { NgModule } from "@angular/core";
import { SeriesSummaryComponent } from "./series-summary.component";
import { CommonModule } from "@angular/common";
import { SeriesDetailsModule } from "../series-details/series-details.module";
import { MatButtonModule } from "@angular/material/button"
import { MatCardModule } from "@angular/material/card";
import { RouterLink } from "@angular/router";
import { AddSeriesModule } from "../add-series/add-series.module";

@NgModule({
    imports: [CommonModule, SeriesDetailsModule, MatButtonModule, MatCardModule, RouterLink, AddSeriesModule],
    declarations: [ SeriesSummaryComponent ],
    exports: [SeriesSummaryComponent ]
})
export class SeriesSummaryModule {}