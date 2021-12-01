import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core/models/App/User';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User | undefined;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    
  }

  login(loginForm: any) {
    this.authService.login(loginForm.email, loginForm.password).subscribe(
      (user) => {
        this.user = user;
        console.log(user)
      },
      err => {
      }
    )
  }
}
