import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core/models/App/User';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  constructor(private authService: AuthService) { }

  ngOnInit(): void {
   
  }
}
