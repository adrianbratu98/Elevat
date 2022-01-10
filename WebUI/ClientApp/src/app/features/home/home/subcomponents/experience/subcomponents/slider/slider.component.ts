import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss']
})
export class SliderComponent implements OnInit {

  selectedPictures: string[] = [
    "/assets/img/hero.jpg",
    "/assets/img/hero2.jpg",
  ]

  selectedPictureIndex: number = 0;

  constructor() { }

  ngOnInit(): void {
    this.changePicture();
  }

  changePicture() { 
    setInterval(() => {
      this.selectedPictureIndex = this.selectedPictures.length - 1 == this.selectedPictureIndex  ?
        this.selectedPictureIndex = 0 :
        this.selectedPictureIndex = this.selectedPictureIndex + 1;
    }, 3500);
  }


}
