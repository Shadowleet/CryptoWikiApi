import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AssetsListComponent } from "./asset-list/asset-list.component";
import { AssetComponent } from "./asset/asset.component";
import { BlockchainListComponent } from "./blockchain-list/blockchain-list.component";
import { BlockchainComponent } from "./blockchain/blockchain.component";
import { NavigationComponent } from "./navigation/navigation.component";
import { UserListComponent } from "./user-list/user-list.component";
import { UserComponent } from "./user/user.component";


const routes: Routes = [
  { path: "assets", component: AssetsListComponent },
  { path: "asset/:id", component: AssetComponent },
  { path: "asset", component: AssetComponent },
  { path: "blockchains", component: BlockchainListComponent },
  { path: "blockchain/:id", component: BlockchainComponent },
  { path: "blockchain", component: BlockchainComponent },
  { path: "users", component: UserListComponent },
  { path: "create-user", component: UserComponent }, // Renamed from "add-user"
  { path: "user/:id", component: UserComponent },
  { path: "", redirectTo: "/assets", pathMatch: "full" },
  { path: "**", redirectTo: "/assets", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}