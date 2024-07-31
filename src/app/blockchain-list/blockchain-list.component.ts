import { Component, OnInit } from "@angular/core";
import { BlockchainService } from "../blockchain.service";
import { Blockchain } from "../blockchain.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-blockchain-list",
  templateUrl: "./blockchain-list.component.html",
  styleUrls: ["./blockchain-list.component.scss"]
})
export class BlockchainListComponent implements OnInit {
  blockchains: Blockchain[] = []; // Array to hold list of blockchains

  constructor(private blockchainService: BlockchainService, private router: Router) { }

  ngOnInit() {
    // Fetch blockchains on component initialization
    this.blockchainService.getAllBlockchains().subscribe((data) => {
      console.log(data);
      this.blockchains = data;
    });
  }

  // Navigate to blockchain details component
  viewBlockchain(id: number) {
    this.router.navigate(["/blockchain", id]);
  }

  // Navigate to new blockchain form
  addBlockchain() {
    this.router.navigate(["/blockchain"]);
  }
  deleteBlockchain(id: number) {
    if (confirm('Are you sure you want to delete this blockchain?')) {
      this.blockchainService.deleteBlockchain(id).subscribe(() => {
        this.blockchains = this.blockchains.filter((blockchain) => blockchain.blockchainId !== id);
      });
    }
  }
}