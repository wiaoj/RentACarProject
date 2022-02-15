import { CarComponent } from './../car/car.component';
import { ColorService } from './../../services/color/color.service';
import { Color } from './../../models/color/color';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css'],
})
export class ColorComponent implements OnInit {
  colors: Color[] = [];
  currentColor: Color;
  colorId: number = 0;
  filterText: string = '';
  //dataLoaded = false;
  constructor(
    private colorService: ColorService,
    private carComponent: CarComponent
  ) {}

  ngOnInit(): void {
    this.getColors();
  }

  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
      //this.dataLoaded = true;
    });
  }

  setCurrentColor() {
    this.carComponent.colorId = this.colorId;
  }
  clearCurrentColor() {
    this.currentColor = { id: 0, name: '' };
    this.colorId = 0;
    this.setCurrentColor();
  }
  getCurrentColorClass(color: Color) {
    if (color == this.currentColor) {
      return 'list-group-item list-group-item-action list-group-item-dark';
    } else {
      return 'list-group-item list-group-item-action list-group-item-light';
    }
  }

  getAllColorClass() {
    if (this.currentColor) {
      return 'list-group-item list-group-item-action list-group-item-light';
    } else {
      return 'list-group-item list-group-item-action list-group-item-dark';
    }
  }
  clearInputBox() {
    this.clearCurrentColor();
    this.filterText = '';
  }
}
