
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { AssetsListComponent } from './asset-list/asset-list.component';
import { AssetComponent } from './asset/asset.component';
import { NavigationComponent } from "./navigation/navigation.component";
import { BlockchainComponent } from './blockchain/blockchain.component';
import { BlockchainListComponent } from './blockchain-list/blockchain-list.component';
import { UserComponent } from './user/user.component';
import { UserListComponent } from './user-list/user-list.component';

@NgModule({
  declarations: [AppComponent, NavigationComponent, AssetsListComponent, AssetComponent, BlockchainComponent, BlockchainListComponent, UserComponent, UserListComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}