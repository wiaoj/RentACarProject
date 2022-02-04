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
  //dataLoaded = false;
  constructor(private colorService: ColorService) {}

  ngOnInit(): void {
    this.getColors();
  }

  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
      //this.dataLoaded = true;
    });
  }

  setCurrentColor(color: Color) {
    this.currentColor = color;
  }
  clearCurrentColor() {
    this.currentColor = { id: 0, name: '' };
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
}
