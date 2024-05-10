import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AddSeriesComponent } from "./add-series.component";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { RouterLink } from "@angular/router";
import { TagModule } from "../../tag/tag.module";
import { MatSlideToggleModule } from "@angular/material/slide-toggle"

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        MatButtonModule,
        MatCardModule,
        RouterLink,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        TagModule,
        MatSlideToggleModule
    ],
    declarations: [AddSeriesComponent],
    exports: [AddSeriesComponent],
})
export class AddSeriesModule {}