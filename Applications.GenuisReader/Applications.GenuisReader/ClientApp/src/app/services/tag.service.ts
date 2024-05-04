import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Tag } from "../models/tag";
import { Observable } from "rxjs";

@Injectable()
export class TagService {
    http: HttpClient;
    readonly api_url = 'https://localhost:7091/api/Tags';
    constructor(http: HttpClient) {
        this.http = http;
    }

    getAllTags(): Observable<Tag[]> {
        return this.http.get<Tag[]>(this.api_url + '/All');
    }
}