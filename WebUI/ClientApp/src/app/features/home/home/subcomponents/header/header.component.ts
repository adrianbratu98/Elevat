import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from 'src/app/core/models/App/User';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {

  user: User | undefined;

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
