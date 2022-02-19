import { ColorService } from './../../services/color/color.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Color } from 'src/app/models/color/color';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-color-update',
  templateUrl: './color-update.component.html',
  styleUrls: ['./color-update.component.css']
})
export class ColorUpdateComponent implements OnInit {
  dataLoaded: boolean = false;
  selectedColor:boolean=false;
  colors: Color[] = [];
  color:Color;
  colorUpdateForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router:Router,
    private colorService: ColorService) {}

  ngOnInit(): void {
    this.getcolors();
    this.createcolorUpdateForm();
  }

  createcolorUpdateForm(colorName:String = "Select color") {
    this.colorUpdateForm = this.formBuilder.group({
      name: [colorName, Validators.required],
    });
  }

  getcolors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
      this.dataLoaded = true;
    });
  }

  selectColor(color:Color){
    this.selectedColor = true;
    this.color = color;
    this.createcolorUpdateForm(color.name);
  }

  update() {
    if (this.colorUpdateForm.valid) {
      let colorModel: Color = {id: this.color.id, ...this.colorUpdateForm.value};
      this.colorService.update(colorModel).subscribe(
        (response) => {
          this.toastr.success(response.message);
          window.location.reload(); //refresh page
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
              this.toastr.error(responseError.error.ValidationErrors[i].ErrorMessage);
            }
          }
        }
      );
    } else {
      this.toastr.error('Formunuz eksik', 'Dikkat');
    }
  }

}
