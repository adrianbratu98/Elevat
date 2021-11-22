import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { HeroSectionComponent } from './home/subcomponents/hero-section/hero-section.component';
import { AboutSectionComponent } from './home/subcomponents/about-section/about-section.component';
import { ServicesSectionComponent } from './home/subcomponents/services-section/services-section.component';
import { WorksSectionComponent } from './home/subcomponents/works-section/works-section.component';
import { TeamSectionComponent } from './home/subcomponents/team-section/team-section.component';
import { BookSectionComponent } from './home/subcomponents/book-section/book-section.component';
import { HeaderComponent } from './home/subcomponents/header/header.component';




@NgModule({
  declarations: [
    HomeComponent,
    HeroSectionComponent,
    AboutSectionComponent,
    ServicesSectionComponent,
    WorksSectionComponent,
    TeamSectionComponent,
    BookSectionComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomeModule { }
