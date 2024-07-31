import { Component, OnInit } from "@angular/core";
import { AssetsService } from "../assets.service";
import { Asset } from "../assets.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-assets-list",
  templateUrl: "./asset-list.component.html",
  styleUrls: ["./asset-list.component.scss"]
})
export class AssetsListComponent implements OnInit {
  assets: Asset[] = []; // Array to hold list of assets

  constructor(private assetsService: AssetsService, private router: Router) { }

  ngOnInit() {
    // Fetch assets on component initialization
    this.assetsService.getAssets().subscribe((data) => {
      console.log(data);
      this.assets = data;
    });
  }

  // Navigate to asset details component
  viewAsset(id: string) {
    this.router.navigate(["/asset", id]);
  }

  // Navigate to new asset form
  addAsset() {
    this.router.navigate(["/asset"]);
  }

  // Delete asset by ID
  deleteAsset(id: string) {
    this.assetsService.deleteAsset(id).subscribe(() => {
      this.assets = this.assets.filter((asset) => asset.id !== id);
    });
  }
  
}
