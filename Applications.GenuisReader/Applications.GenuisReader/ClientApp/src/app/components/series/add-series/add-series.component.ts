import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";

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
export class AddSeriesComponent implements OnInit{
    titleFormControl!: FormControl;
    startDateControl!: FormControl;
    endDateControl!: FormControl<Date|null>;

    ngOnInit(): void {
        this.titleFormControl = new FormControl<string>('');
        this.startDateControl = new FormControl<Date>(new Date(1900, 0, 1));
        this.endDateControl = new FormControl<Date|null>(null);
    }
}