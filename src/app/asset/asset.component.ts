import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AssetsService } from '../assets.service';
import { Asset } from '../assets.model';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-asset',
  templateUrl: './asset.component.html',
  styleUrls: ['./asset.component.scss']
})
export class AssetComponent implements OnInit {
  asset: Asset = {
    id: '',
    name: "",
    symbolUrl: "",
    marketCap: 0,
    website: "",
    launchDate: new Date(),
    description: "",
    blockchainId: 0,
    createDate: new Date(),
    isDeleted: false
  };
  isEditing = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private assetsService: AssetsService
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.assetsService.getAsset(id).subscribe(data => {
        this.asset = data;
        this.isEditing = true;
      });
    }
  }

  saveAsset() {
    let assetOperation = this.isEditing ? this.assetsService.updateAsset(this.asset) : this.assetsService.addAsset(this.asset);

    assetOperation.subscribe(
      () => {
        this.router.navigate(['/assets']);
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

  deleteAsset() {
    if (confirm('Are you sure you want to delete this asset?')) {
      this.assetsService.deleteAsset(this.asset.id).subscribe(
        () => {
          this.router.navigate(['/assets']);
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
    this.router.navigate(['/assets']);
  }
}
