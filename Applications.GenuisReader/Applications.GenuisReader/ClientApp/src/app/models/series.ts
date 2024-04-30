import { Author, blankAuthor } from "./author";
import { Chapter } from "./chapter";
import { Tag } from "./tag";

export class Series {
    public seriesId: number;
    public title: String;
    public startDate: String;
    public endDate: String;
    public authors: Author[];
    public tags: Tag[];
    public isOngoing: Boolean;
    
    constructor(seriesId: number, title: String, startDate: String, endDate: String, authors: Author[], tags: Tag[], ongoing: Boolean, public chapters: Chapter[]) {
        this.seriesId = seriesId;
        this.title = title;
        this.startDate = startDate;
        this.endDate = endDate;
        this.authors = authors;
        this.tags = tags;
        this.isOngoing = ongoing;
    }
}

export const blankSeries: Series  = {
    seriesId: 0,
    title: 'Blank',
    startDate: '1900-01-01',
    endDate: '',
    authors: [blankAuthor],
    tags: [],
    isOngoing: false,
    chapters: [],
}