import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatChipsModule } from "@angular/material/chips";
import { TagComponent } from "./tag.component";

@NgModule({
    imports: [ CommonModule, MatChipsModule ],
    declarations: [ TagComponent ],
    exports: [ TagComponent ]
})
export class TagModule {}