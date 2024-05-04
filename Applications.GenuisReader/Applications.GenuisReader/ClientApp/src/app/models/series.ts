import { Author, blankAuthor } from "./author";
import { Chapter } from "./chapter";
import { Tag } from "./tag";

export class Series {
    public seriesId: number;
    public title: String;
    public startDate: Date;
    public endDate: Date|null;
    public authors: Author[];
    public tags: Tag[];
    public isOngoing: Boolean;
    
    constructor(seriesId: number, title: String, startDate: Date, endDate: Date, authors: Author[], tags: Tag[], ongoing: Boolean, public chapters: Chapter[]) {
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
    startDate: new Date(1900, 0, 1),
    endDate: null,
    authors: [blankAuthor],
    tags: [],
    isOngoing: false,
    chapters: [],
}