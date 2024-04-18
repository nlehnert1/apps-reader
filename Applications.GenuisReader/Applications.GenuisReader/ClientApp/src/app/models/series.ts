import { Author, blankAuthor } from "./author";
import { Chapter } from "./chapter";
import { Tag } from "./tag";

export class Series {
    public seriesId: Number;
    public title: String;
    public authors: Author[];
    public tags: Tag[];
    public isOngoing: Boolean;
    
    constructor(seriesId: Number, title: String, authors: Author[], tags: Tag[], ongoing: Boolean, public chapters: Chapter[]) {
        this.seriesId = seriesId;
        this.title = title;
        this.authors = authors;
        this.tags = tags;
        this.isOngoing = ongoing;
    }
}

export const blankSeries: Series  = {
    seriesId: 0,
    title: 'Blank',
    authors: [blankAuthor],
    tags: [],
    isOngoing: false,
    chapters: [],
}