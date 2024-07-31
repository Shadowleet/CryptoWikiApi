import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlockchainService } from '../blockchain.service';
import { Blockchain } from '../blockchain.model';

@Component({
  selector: 'app-blockchain',
  templateUrl: './blockchain.component.html',
  styleUrls: ['./blockchain.component.scss']
})
export class BlockchainComponent implements OnInit {
  blockchain: Blockchain = {
    blockchainId:0,
    name: "",
    createdDate: new Date(),
    isDeleted: false
  };
  isEditing = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private blockchainService: BlockchainService
  ) { }

  ngOnInit() {
    const idString = this.route.snapshot.paramMap.get('id');
    if (idString) {
      const id = parseInt(idString, 10); // Parse the string to a number
      this.blockchainService.getBlockchain(id).subscribe(data => {
        this.blockchain = data;
      });
      this.isEditing = true;
    }
  }

  saveBlockchain() {
  if (this.isEditing) {
    this.blockchainService.updateBlockchain(this.blockchain).subscribe(
      () => {
        this.router.navigate(['/blockchains']);
      },
      (error) => {
        console.error('Error updating blockchain:', error);
        alert('Error updating blockchain: ' + error.message); // Add this line
      }
    );
  } else {
    this.blockchainService.addBlockchain(this.blockchain).subscribe(
      () => {
        this.router.navigate(['/blockchains']);
      },
      (error) => {
        console.error('Error adding blockchain:', error);
        alert('Error adding blockchain: ' + error.message); // Add this line
      }
    );
  }
}

  deleteBlockchain() {
    if (confirm('Are you sure you want to delete this blockchain?')) {
      // Assuming your blockchain id needs to be a number, convert it if necessary
      const blockchainId = (this.blockchain.blockchainId, 10);

      this.blockchainService.deleteBlockchain(blockchainId).subscribe(() => {
        this.router.navigate(['/blockchains']);
      });
    }
  }

  goBack() {
    this.router.navigate(['/blockchains']);
  }
}