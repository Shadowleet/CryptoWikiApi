import { Component, OnInit } from "@angular/core";
import { UserService } from "../user.service";
import { User } from "../user.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-user-list",
  templateUrl: "./user-list.component.html",
  styleUrls: ["./user-list.component.scss"]
})
export class UserListComponent implements OnInit {
  users: User[] = []; // Array to hold list of users

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe((data) => {
      console.log(data);
      this.users = data;
    });
  }

  // Navigate to user details component
  viewUser(id: number) {
    this.router.navigate(["/user", id]);
  }

  // Navigate to new user form
  addUser() {
    this.router.navigate(["/create-user"]);
  }

  // Delete user by ID
  deleteUser(id: number) {
    this.userService.deleteUser(id).subscribe(() => {
      this.users = this.users.filter((user) => user.userId !== id);
    });
  }
}