
export class Author {
    public firstName: String;
    public lastName: String;
    constructor(firstName: String, lastName: String) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}

export const blankAuthor: Author = {
    firstName: '',
    lastName: '',
}