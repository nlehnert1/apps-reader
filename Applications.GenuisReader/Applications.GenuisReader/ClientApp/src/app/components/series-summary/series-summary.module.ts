import { NgModule } from "@angular/core";
import { SeriesSummaryComponent } from "./series-summary.component";
import { CommonModule } from "@angular/common";

@NgModule({
    imports: [CommonModule],
    declarations: [ SeriesSummaryComponent ],
    exports: [SeriesSummaryComponent ]
})
export class SeriesSummaryModule {}