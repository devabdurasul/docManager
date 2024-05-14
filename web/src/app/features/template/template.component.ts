import { Component } from '@angular/core';
import {EditorModule} from "@tinymce/tinymce-angular";

@Component({
  selector: 'app-template',
  standalone: true,
    imports: [
        EditorModule
    ],
  templateUrl: './template.component.html',
  styleUrl: './template.component.scss'
})
export class TemplateComponent {

}
