import { Component, OnInit, Output, EventEmitter, Input } from "@angular/core";
import { TagService } from "../../services/tag.service";
import { Tag } from "../../models/tag";

@Component({
    selector: 'reader-tag-select',
    templateUrl: './tag.component.html',
    styleUrl: './tag.component.scss'
})
export class TagComponent implements OnInit {
    allTags!: Tag[];
    @Input() displaySensitiveTags: boolean = false;
    @Output() selectedTagsChangeEvent = new EventEmitter<Tag>();
    constructor(public tagService: TagService) {}

    ngOnInit(): void {
        this.tagService.getAllTags().subscribe(resp => {
            this.allTags = resp;
        });
    }

    onChipSelect(tagChip: Tag): void {
        this.selectedTagsChangeEvent.emit(tagChip);
    }
}