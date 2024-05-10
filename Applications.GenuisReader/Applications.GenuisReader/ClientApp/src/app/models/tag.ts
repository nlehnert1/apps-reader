export class Tag {
    public tagId: number;
    public label: String;
    public description: String;
    public isSensitive: boolean;
    constructor(id: number, label: String, description: String, isSensitive: boolean) {
        this.tagId = id;
        this.label = label;
        this.description = description;
        this.isSensitive = isSensitive;
    }
}