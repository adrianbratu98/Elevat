import { ChangeDetectorRef, Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from 'src/app/core/models/App/User';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  user: User | undefined;

  check:boolean = false;

  userLoggedInSubs: Subscription | undefined;

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.user = this.authService.user;
    this.userLoggedInSubs = this.authService.userLoggedIn.subscribe(
      (userLoggedIn: boolean) => {
        this.user = undefined;
        if(userLoggedIn) {
          this.user = this.authService.user;
        }
        else {
          this.user = undefined;
        }
      }
    )
  }

  ngOnDestroy() {
    this.userLoggedInSubs?.unsubscribe();
  }

  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {
    let element = document.querySelector('.navbar') as HTMLElement;
    if (window.pageYOffset > element.clientHeight) {
      element.classList.add('navbar-custom');
    } else {
      element.classList.remove('navbar-custom');
    }
  }

  goToAdmin() {
    this.router.navigateByUrl("/admin");
  }

  goToAuth() {
    this.router.navigateByUrl("/auth");
  }

  logout() {
    this.authService.logout();
    this.user = undefined;
  }
}
