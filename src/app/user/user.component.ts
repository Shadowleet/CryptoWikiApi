import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../user.model';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  user: User = {
    userId: 0,
    firstName: '',
    lastName: '',
    email: '',
    isActive: false,
    isDeleted: false,
    dateCreated: new Date()
  };
  isEditing = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit() {
    const idParam = this.route.snapshot.paramMap.get('id');
  if (idParam !== null) {
    const id = parseInt(idParam, 10);
    if (id) {
      this.userService.getUser(id).subscribe(data => {
        this.user = data;
        this.isEditing = true;
      });
    }
  }
}

  saveUser() {
    let userOperation = this.isEditing ? this.userService.updateUser(this.user) : this.userService.addUser(this.user);

    userOperation.subscribe(
      () => {
        this.router.navigate(['/users']);
      },
      (error: HttpErrorResponse) => {
        let errorMessage = 'Unknown error occurred!';
        if (error.error instanceof ErrorEvent) {
          // Client-side errors
          errorMessage = `Error: ${error.error.message}`;
        } else {
          // Server-side errors
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.error(errorMessage);
        // Optionally, you can throw an application-specific error here:
        return throwError(errorMessage);
      }
    );
  }

  deleteUser() {
    if (confirm('Are you sure you want to delete this user?')) {
      const id = parseInt(this.user.userId.toString(), 10);
      this.userService.deleteUser(id).subscribe(
        () => {
          this.router.navigate(['/users']);
        },
        (error: HttpErrorResponse) => {
          let errorMessage = 'Unknown error occurred!';
          if (error.error instanceof ErrorEvent) {
            // Client-side errors
            errorMessage = `Error: ${error.error.message}`;
          } else {
            // Server-side errors
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
          }
          console.error(errorMessage);
          // Optionally, you can throw an application-specific error here:
          return throwError(errorMessage);
        }
      );
    }
  }

  goBack() {
    this.router.navigate(['/users']);
  }
}