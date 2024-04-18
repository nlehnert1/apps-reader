import { Tag } from "./tag";

export class Chapter {
    constructor(public chapterId: Number, public title: String, public tags: Tag[]) { }
}