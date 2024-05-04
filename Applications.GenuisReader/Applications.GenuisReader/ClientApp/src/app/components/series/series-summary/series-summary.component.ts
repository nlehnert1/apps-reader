import { Component, OnInit } from "@angular/core";
import { SeriesService } from "../../../services/series.service";
import { Series } from "../../../models/series";

@Component({
    selector: 'series-summary',
    templateUrl: './series-summary.component.html',
    styleUrl: './series-summary.component.scss'
})
export class SeriesSummaryComponent implements OnInit {
    series: Series[] = [];
    hasSeriesSelected: Boolean = false;
    constructor(public seriesService: SeriesService) { }
    ngOnInit() {
        this.seriesService.getSeriesSummaries().subscribe(resp => {
            this.series = resp
        });
        this.seriesService.selectedSeriesId.subscribe(newValue => {
            this.hasSeriesSelected = newValue > 0;
        })
    }

    public getFormattedAuthorStrings(series: Series) : String {
        let fullNameArray: String[] = [];
        series.authors.forEach(a => fullNameArray.push(a.firstName != undefined ? `${a.firstName} ${a.lastName}` : `${a.lastName}`));
        return fullNameArray.join(', ');
    }

    onSelectSeries(seriesId: number) {
        console.log('Hit "OnSelectSeries" for seriesId:', seriesId);
        this.seriesService.selectedSeriesId.next(seriesId);
    }
}