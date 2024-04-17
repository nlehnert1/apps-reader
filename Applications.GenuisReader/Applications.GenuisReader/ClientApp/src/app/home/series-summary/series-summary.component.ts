import { Component, OnInit } from "@angular/core";
import { Series, SeriesService } from "./series-summary.service";
import { Observable } from "rxjs";

@Component({
    selector: 'series-summary',
    templateUrl: './series-summary.component.html',
})
export class SeriesSummaryComponent implements OnInit {
    series: Series[] = [];
    constructor(public seriesService: SeriesService) { }
    ngOnInit() {
        this.seriesService.getSeriesSummaries().subscribe(resp => {
            this.series = resp
        });
    }
}