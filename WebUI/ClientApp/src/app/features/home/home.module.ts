import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ExperienceComponent } from './home/subcomponents/experience/experience.component';
import { AboutSectionComponent } from './home/subcomponents/about-section/about-section.component';
import { ServicesSectionComponent } from './home/subcomponents/services-section/services-section.component';
import { WorksSectionComponent } from './home/subcomponents/works-section/works-section.component';
import { TeamSectionComponent } from './home/subcomponents/team-section/team-section.component';
import { BookSectionComponent } from './home/subcomponents/book-section/book-section.component';
import { HeaderComponent } from './home/subcomponents/header/header.component';
import { CarouselComponent } from './home/subcomponents/experience/subcomponents/carousel/carousel.component';
import { SliderComponent } from './home/subcomponents/experience/subcomponents/slider/slider.component';




@NgModule({
  declarations: [
    HomeComponent,
    ExperienceComponent,
    AboutSectionComponent,
    ServicesSectionComponent,
    WorksSectionComponent,
    TeamSectionComponent,
    BookSectionComponent,
    HeaderComponent,
    CarouselComponent,
    SliderComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomeModule { }
