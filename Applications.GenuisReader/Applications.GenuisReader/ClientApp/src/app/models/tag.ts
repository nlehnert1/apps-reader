export class Tag {
    public tagId: number;
    public label: String;
    public description: String;
    constructor(id: number, label: String, description: String) {
        this.tagId = id;
        this.label = label;
        this.description = description;
    }
}