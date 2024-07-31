import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlockchainListComponent } from './blockchain-list.component';

describe('BlockchainListComponent', () => {
  let component: BlockchainListComponent;
  let fixture: ComponentFixture<BlockchainListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BlockchainListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BlockchainListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
