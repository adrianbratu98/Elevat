import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  check:boolean = false;

  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {
    let element = document.querySelector('.navbar') as HTMLElement;
    if (window.pageYOffset > element.clientHeight) {
      element.classList.add('navbar-custom');
    } else {
      element.classList.remove('navbar-custom');
    }
  }

  toggle(){
    if(this.check == false)
      this.check = true;
    else
      this.check = false;
  }

  goToAdmin() {
    this.router.navigateByUrl("/admin");
  }

  goToAuth() {
    this.router.navigateByUrl("/auth");
  }
}
