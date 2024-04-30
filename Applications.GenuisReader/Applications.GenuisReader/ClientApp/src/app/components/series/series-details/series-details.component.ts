import { Component, OnInit } from "@angular/core";
import { SeriesService } from "../../../services/series.service";
import { Series, blankSeries } from "../../../models/series";

@Component({
    selector: 'series-detail',
    templateUrl: './series-details.component.html',
    styleUrl: './series-details.component.scss'
})
export class SeriesDetailsComponent implements OnInit {
    constructor(private seriesService: SeriesService) { }
    selectedSeriesId: Number = 0;
    defaultSeriesId: Number = 1;
    selectedSeries: Series = blankSeries;

    ngOnInit(): void {
        this.selectedSeriesId = this.defaultSeriesId;
        this.seriesService.getSeriesDetails(this.selectedSeriesId).subscribe(resp => {
            this.selectedSeries = resp;
        })
        this.seriesService.selectedSeriesId.subscribe(val => {
            this.seriesService.getSeriesDetails(val).subscribe(resp => {
                this.selectedSeries = resp;
            });
        });
    }

    public getFormattedAuthorStrings() : String {
        let fullNameArray: String[] = [];
        this.selectedSeries.authors.forEach(a => fullNameArray.push(a.firstName != undefined ? `${a.firstName} ${a.lastName}` : `${a.lastName}`));
        return fullNameArray.join(', ');
    }

    public getTagsList() : String {
        let tagsList: String[] = [];
        this.selectedSeries.tags.forEach(t => tagsList.push(t.label));
        return tagsList.join(', ');
    }

    public getChapterTags(chapterId: Number) : String {
        let tagsList: String[] = [];
        this.selectedSeries.chapters.find(chap => chap.chapterId == chapterId)?.tags.forEach(t => tagsList.push(t.label));
        return tagsList.join(', ')
    }
}