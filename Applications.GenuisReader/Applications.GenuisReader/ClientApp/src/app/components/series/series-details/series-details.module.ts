import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SeriesDetailsComponent } from "./series-details.component";

@NgModule({
    imports: [CommonModule],
    declarations: [SeriesDetailsComponent],
    exports: [SeriesDetailsComponent],
})
export class SeriesDetailsModule {}