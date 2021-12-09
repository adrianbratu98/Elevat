import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AccountListDto } from 'src/app/core/models/Dto/account-list-dto';
import { UsersService } from 'src/app/core/services/users.service';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit, OnDestroy {

  users: AccountListDto[] | undefined;
  getUsersSubs: Subscription | undefined;

  constructor(private userService: UsersService) { }

  ngOnInit(): void {
    this.getUsersSubs = this.userService.getList().subscribe(
      (users) => {
        this.users = users;
      }
    )
  }
    
  ngOnDestroy(): void {
    if(!this.getUsersSubs?.closed)
      this.getUsersSubs?.unsubscribe()
  }
}
