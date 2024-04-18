import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, last, of } from "rxjs";

export class Series {
    public title: Text;
    public author: Author;
    constructor(title: Text, author: Author) {
        this.title = title;
        this.author = author
    }
}

export class Author {
    public firstName: Text;
    public lastName: Text;
    constructor(firstName: Text, lastName: Text) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}

@Injectable()
export class SeriesService {
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
     }
    
    api_url = 'https://localhost:7091/api/Series'

    getSeriesSummaries() : Observable<Series[]> {
        return this.http.get<Series[]>(this.api_url + '/Summaries');
    } 
}