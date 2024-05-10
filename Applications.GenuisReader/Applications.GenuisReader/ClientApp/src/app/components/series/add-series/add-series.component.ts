import { Component, OnChanges, OnInit, Output, SimpleChange, SimpleChanges } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Series } from "../../../models/series";
import { Author } from "../../../models/author";
import { SeriesService } from "../../../services/series.service";
import { TagService } from "../../../services/tag.service";
import { Tag } from "../../../models/tag";

@Component({
    selector: 'add-series',
    templateUrl: './add-series.component.html',
    styleUrl: './add-series.component.scss'
})
export class AddSeriesComponent implements OnInit{
    titleFormControl!: FormControl;
    startDateControl!: FormControl;
    endDateControl!: FormControl<Date|null>;
    familyNameControl!: FormControl;
    givenNameControl!: FormControl;
    selectedTags!: Tag[];
    ableToSubmit!: boolean;
    hasAtLeastOneTag!: boolean;
    hasValidAuthor!: boolean;
    hasValidStartDate!: boolean;
    hasValidTitle!: boolean;
    submitValidationMessage!: string;
    submittedSeries!: Series|null;
    showSensitiveTags: boolean = false;

    constructor(public seriesService: SeriesService) { }

    ngOnInit(): void {
        this.titleFormControl = new FormControl<string>('');
        this.startDateControl = new FormControl<Date|null>(null);
        this.endDateControl = new FormControl<Date|null>(null);
        this.familyNameControl = new FormControl<string>('');
        this.givenNameControl = new FormControl<string>('');
        this.selectedTags = [];
        this.ableToSubmit = false;
        this.hasAtLeastOneTag = false;
        this.hasValidAuthor = false;
        this.hasValidStartDate = false;
        this.hasValidTitle = false;
        this.submitValidationMessage = '';
        this.submittedSeries = null;
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
        this.hasValidTitle = this.titleFormControl.value !== '';
        this.hasValidStartDate = this.startDateControl.value !== null;
        this.hasValidAuthor = this.familyNameControl.value !== '';
        this.hasAtLeastOneTag = this.selectedTags.length >= 1;
        if(!(this.hasAtLeastOneTag && this.hasValidAuthor && this.hasValidTitle && this.hasValidStartDate)) {
            this.submitValidationMessage = "Error: Could not submit. Series must have at least one tag, a valid author, a valid title, and a valid start date.";
            return;
        } else {
            this.submitValidationMessage = '';
        }

        const seriesToSave = {
            title: this.titleFormControl.value,
            startDate: this.startDateControl.value,
            endDate: this.endDateControl.value,
            authors: [{firstName: this.givenNameControl.value, lastName: this.familyNameControl.value}] as Author[],
            tags: this.selectedTags,
        } as Series;

        console.log(seriesToSave);

        this.seriesService.addSeries(seriesToSave).subscribe(resp => {
            this.submittedSeries = resp;
        })
    }

    public getTagsList() : String {
        let tagsList: String[] = [];
        this.submittedSeries?.tags.forEach(t => tagsList.push(t.label));
        return tagsList.join(', ');
    }
}