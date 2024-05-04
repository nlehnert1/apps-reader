import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Series } from "../models/series";

@Injectable()
export class SeriesService {
    http: HttpClient;
    selectedSeriesId: BehaviorSubject<number> = new BehaviorSubject<number>(0);
    constructor(http: HttpClient) {
        this.http = http;
     }
    
    api_url = 'https://localhost:7091/api/Series'

    getSeriesSummaries() : Observable<Series[]> {
        return this.http.get<Series[]>(this.api_url + '/Summaries');
    }

    getSeriesDetails(seriesId: Number) : Observable<Series> {
        return this.http.get<Series>(this.api_url + `/Details/${seriesId}`);
    }

    addSeries(series: Series) : Observable<Series> {
        return this.http.post<Series>(this.api_url + '/AddNew', series);
    }
}