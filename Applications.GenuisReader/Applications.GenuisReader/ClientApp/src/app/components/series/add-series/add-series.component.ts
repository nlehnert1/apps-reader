import { Component, OnChanges, OnInit, SimpleChange, SimpleChanges } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Series } from "../../../models/series";
import { Author } from "../../../models/author";
import { SeriesService } from "../../../services/series.service";
import { TagService } from "../../../services/tag.service";
import { Tag } from "../../../models/tag";

interface AuthorForm {
    firstName: FormControl<string>,
    lastName: FormControl<string>
}
interface SeriesForm {
    title: FormControl<string>,
    authors: FormGroup<AuthorForm>
}

@Component({
    selector: 'add-series',
    templateUrl: './add-series.component.html',
    styleUrl: './add-series.component.scss'
})
export class AddSeriesComponent implements OnInit, OnChanges{
    titleFormControl!: FormControl;
    startDateControl!: FormControl;
    endDateControl!: FormControl<Date|null>;
    familyNameControl!: FormControl;
    givenNameControl!: FormControl;
    selectedTags!: Tag[];
    ableToSubmit!: boolean;

    constructor(public seriesService: SeriesService) { }

    ngOnInit(): void {
        this.titleFormControl = new FormControl<string>('');
        this.startDateControl = new FormControl<Date|null>(null);
        this.endDateControl = new FormControl<Date|null>(null);
        this.familyNameControl = new FormControl<string>('');
        this.givenNameControl = new FormControl<string>('');
        this.selectedTags = [];
        this.ableToSubmit = false;
    }

    ngOnChanges(changes: SimpleChanges): void {
        console.log("touched OnChanges");
        const hasValidTitle = this.titleFormControl.value !== '';
        const hasValidStartDate = this.startDateControl.value !== null;
        const hasValidAuthor = this.familyNameControl.value !== '';
        const hasAtLeastOneTag = this.selectedTags.length >= 1;
        this.ableToSubmit = hasAtLeastOneTag && hasValidAuthor && hasValidStartDate && hasValidTitle;
    }

    updateTags(tag: Tag) {
        const index = this.selectedTags.indexOf(tag);
        if(index >= 0) {
            this.selectedTags.splice(index, 1);
        } else {
            this.selectedTags.push(tag);
        }
        console.log('this.selectedTags:' + this.selectedTags);
    }

    saveSeries(): void {
        const seriesToSave = {
            title: this.titleFormControl.value,
            startDate: this.startDateControl.value,
            endDate: this.endDateControl.value,
            authors: [{firstName: this.givenNameControl.value, lastName: this.familyNameControl.value}] as Author[],
            tags: this.selectedTags,
        } as Series;
    } 
}